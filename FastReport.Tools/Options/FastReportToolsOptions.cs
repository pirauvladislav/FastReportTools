using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReport.DictionaryExtension.Options
{
    [Guid("6374B7E6-60B8-46E3-9FE4-58C65591F2A2")]
    public class FastReportToolsOptions: DialogPage
    {
        private string _designerInstallPath = string.Empty;

        public string DesignerInstallPath
        {
            get { return _designerInstallPath; }
            set { _designerInstallPath = value; }
        }
        protected override IWin32Window Window
        {
            get
            {
                var page = new GeneralSettingsPage();
                page.optionsPage = this;
                page.Initialize();
                return page;
            }
        }

    }
}
