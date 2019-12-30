using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FastReport.DictionaryExtension.Utils;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell.Settings;
using Microsoft.Win32;
using Task = System.Threading.Tasks.Task;

namespace FastReport.DictionaryExtension.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class OpenFastReportDesigner
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 256;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("e5109227-5ee7-4bf8-a17b-ce2e1c06bae9");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFastReportDesigner"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private OpenFastReportDesigner(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static OpenFastReportDesigner Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        const string settingsCollectionName = "FastReport.Community.Designer.Settings";
        const string settingsPropertyName = "Path";

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in OpenFastReportDesigner's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new OpenFastReportDesigner(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var explorer = new SolutionExplorer(this.package);
            var reportFilePath = explorer.GetSelectedFilePath();

            if (Path.GetExtension(reportFilePath) == ".frx")
            {
                var designerIntsallPath = GetDesingerInstallPath(); 
                if (string.IsNullOrEmpty(designerIntsallPath))
                    return;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.CreateNoWindow = false;
                //startInfo.UseShellExecute = false;
                startInfo.FileName = designerIntsallPath;
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                startInfo.Arguments = reportFilePath;

                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    string title = "Open FastReport Designer Error";

                    // Show a message box to prove we were here
                    VsShellUtilities.ShowMessageBox(
                        this.package,
                        ex.Message,
                        title,
                        OLEMSGICON.OLEMSGICON_INFO,
                        OLEMSGBUTTON.OLEMSGBUTTON_OK,
                        OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                }
            }
            else
            {
                VsShellUtilities.ShowMessageBox(
                                this.package,
                                "Please select a FastReport(.frx) file",
                                "Wrong file",
                                OLEMSGICON.OLEMSGICON_INFO,
                                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }

        private string SetDesingnerInstallPath(){ //(SettingsManager settingsManager) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select FastReport Community Designer";
            openFileDialog.Filter = "Executable Files|*.exe";
            if (openFileDialog.ShowDialog() == true)
            {
                /* WritableSettingsStore settingsStoreW = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
                 settingsStoreW.CreateCollection(settingsCollectionName);
                 settingsStoreW.SetString(settingsCollectionName, settingsPropertyName, openFileDialog.FileName);
                 return openFileDialog.FileName;*/
                var fpakage = this.package as FastReportToolsPackage;
                fpakage.FastReportToolOptionsDialogPage.DesignerInstallPath = openFileDialog.FileName;
                fpakage.FastReportToolOptionsDialogPage.SaveSettingsToStorage();
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        private string GetDesingerInstallPath()
        {
            /*SettingsManager settingsManager = new ShellSettingsManager(package);
            SettingsStore settingsStore = settingsManager.GetReadOnlySettingsStore(SettingsScope.UserSettings);

            if (settingsStore.CollectionExists(settingsCollectionName))
                return settingsStore.GetString(settingsCollectionName, settingsPropertyName);
            
            return SetDesingnerInstallPath(settingsManager);*/

            var fpakage = this.package as FastReportToolsPackage;
            var designerPath = fpakage.FastReportToolOptionsDialogPage.DesignerInstallPath;
            if (!string.IsNullOrWhiteSpace(designerPath) && File.Exists(designerPath)){
                return designerPath;
            }
            else
            {
                return SetDesingnerInstallPath();
            }
        } 
    }
}
