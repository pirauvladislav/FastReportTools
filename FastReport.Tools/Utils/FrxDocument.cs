using FastReport.DictionaryExtension.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FastReport.DictionaryExtension.Utils
{
    public class FrxDocument
    {
        private XDocument _frxDocument;
        private string _frxDocumentPath;
        public FrxDocument(string frxFilePath)
        {
            frxFilePath.CheckIsValidFilePath();
            _frxDocumentPath = frxFilePath;
            var frxFileContent = File.ReadAllText(frxFilePath);
            frxFileContent = frxFileContent.Replace("&#13;&#10;", "[&amp;#13;&amp;#10;]");

            _frxDocument = XDocument.Parse(frxFileContent);
        }

        public void UpdateDictionary(IEnumerable<Table> tables, IEnumerable<Relation> relations)
        {
            var frdDictionary = new XElement("Dictionary");
            foreach (var table in tables)
            {
                var frdTableDataSource = new XElement("TableDataSource");
                frdTableDataSource.SetAttributeValue("Name", table.Name);
                frdTableDataSource.SetAttributeValue("ReferenceName", table.ReferenceName);
                frdTableDataSource.SetAttributeValue("Enabled", "true");
                frdDictionary.Add(frdTableDataSource);

                foreach (var field in table.Fields)
                {
                    var frdColumn = new XElement("Column");
                    frdColumn.SetAttributeValue("Name", field.Name);
                    frdColumn.SetAttributeValue("DataType", field.DataType);
                    frdTableDataSource.Add(frdColumn);
                }
            }

            foreach (var relation in relations)
            {
                    var frdRelation = new XElement("Relation");
                    frdRelation.SetAttributeValue("Name", relation.Name);
                    frdRelation.SetAttributeValue("ReferenceName", relation.ReferenceName);
                    frdRelation.SetAttributeValue("ParentDataSource", relation.ParentDataSource);
                    frdRelation.SetAttributeValue("ChildDataSource", relation.ChildDataSource);
                    frdRelation.SetAttributeValue("ParentColumns", relation.ParentColumns);
                    frdRelation.SetAttributeValue("ChildColumns", relation.ChildColumns);
                    frdRelation.SetAttributeValue("Enabled", "true");
                    frdDictionary.Add(frdRelation);
            }

            UpdateReportElement("Dictionary", frdDictionary);

            var frxFileContent = _frxDocument.ToString();
            frxFileContent = $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{frxFileContent.Replace("[&amp;#13;&amp;#10;]", "&#13;&#10;")}";
            File.WriteAllText(_frxDocumentPath, frxFileContent);
        }

        private void UpdateReportElement(string elementName, XElement element)
        {
            var reportElement = _frxDocument.Element("Report");
            reportElement.Element(elementName).Remove();
            reportElement.Add(element);
        }
    }
}
