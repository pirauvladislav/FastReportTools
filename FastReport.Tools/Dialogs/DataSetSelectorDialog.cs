using FastReport.DictionaryExtension.Models;
using FastReport.DictionaryExtension.UserControls;
using FastReport.DictionaryExtension.Utils;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.DictionaryExtension.Dialogs
{
    internal class DataSetSelectorDialog : DialogWindow
    {
        public DataSetSelectorDialog(IEnumerable<DataSet> dataSets, string reportFileParh  )
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var tableSelector = new DataSetSelector(dataSets, reportFileParh);
            this.Width = 600;
            this.Height = 500;
            this.Content = tableSelector;
        }
    }
}
