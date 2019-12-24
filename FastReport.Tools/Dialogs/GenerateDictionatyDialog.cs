using FastReport.DictionaryExtension.UserControls;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.DictionaryExtension.Dialogs
{
    public class GenerateDictionatyDialog : DialogWindow
    {
        public GenerateDictionatyDialog(string dataSetFilePath)
        {
            this.Width = 600;
            this.Height = 440;
            var generator = new XsdGenerator(dataSetFilePath);
            this.Content = generator;
        }
    }
}
