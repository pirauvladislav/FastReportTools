using System;
using System.Runtime.InteropServices;
using System.Threading;
using FastReport.DictionaryExtension.Options;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using Task = System.Threading.Tasks.Task;

namespace FastReport.DictionaryExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(FastReportToolsPackage.PackageGuidString)]

    [ProvideUIContextRule(UiContextSupportedFrxFiles,
        name: "Supported Files",
        expression: "FastReport",
        termNames: new[] { "FastReport" },
        termValues: new[] { "HierSingleSelectionName:.frx$" })]
    [ProvideUIContextRule(UiContextSupportedXsdFiles,
        name: "Supported Files",
        /*expression: "CSharp | VisualBasic",
        termNames: new[] { "CSharp", "VisualBasic" },
        termValues: new[] { "HierSingleSelectionName:.cs$", "HierSingleSelectionName:.vb$" })]*/
        expression: "DataSet",
        termNames: new[] { "DataSet" },
        termValues: new[] { "HierSingleSelectionName:.xsd$" })]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(FastReportToolsOptions),"FastReport Tools", "General", 0, 0, true)]
    public sealed class FastReportToolsPackage : AsyncPackage
    {
         /// <summary>
        /// FastReport.DictionaryExtensionPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "d8fc6792-b028-43d1-ae1e-a9ed6e6dc2fd";
        private const string UiContextSupportedFrxFiles = "E6AA3BBC-D199-4C76-A8E0-50EE86123DC5";
        private const string UiContextSupportedXsdFiles = "C781A62B-9EBE-4E3A-94DD-20C7FE62EB3C";

        public FastReportToolsOptions FastReportToolOptionsDialogPage
        {
            get
            {
                return (FastReportToolsOptions)GetDialogPage(typeof(FastReportToolsOptions));
            }
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await Commands.ImportDataSet.InitializeAsync(this);
            await Commands.GenerateDictionary.InitializeAsync(this);
            await Commands.OpenFastReportDesigner.InitializeAsync(this);
        }

        #endregion
    }
}
