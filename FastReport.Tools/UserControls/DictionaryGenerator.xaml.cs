using FastReport.DictionaryExtension.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FastReport.DictionaryExtension.UserControls
{
    /// <summary>
    /// Interaction logic for XsdGenerator.xaml
    /// </summary>
    public partial class XsdGenerator : UserControl
    {
        private XDocument _xDocument;
        public XsdGenerator(string xsdFilePath)
        {
            InitializeComponent();
            _xDocument =  XsdParser.GenerateXmlDictionary(xsdFilePath);
            tbDictionaryXml.Text = _xDocument.ToString();
        }

        private void btCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(tbDictionaryXml.Text);
        }

        private void btSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                _xDocument.Save(saveFileDialog.FileName);
        }
    }
}
