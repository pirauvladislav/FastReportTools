using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReport.DictionaryExtension.Options
{
    public partial class GeneralSettingsPage : UserControl
    {
        internal FastReportToolsOptions optionsPage;
        public GeneralSettingsPage()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.tbInstallPath.Text = optionsPage.DesignerInstallPath;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select FastReport Community Designer";
            openFileDialog.Filter = "Executable Files|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbInstallPath.Text = openFileDialog.FileName;
                optionsPage.DesignerInstallPath = this.tbInstallPath.Text;
            }
        }
    }
}
