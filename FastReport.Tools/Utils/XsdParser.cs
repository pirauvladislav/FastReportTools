using FastReport.DictionaryExtension.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace FastReport.DictionaryExtension.Utils
{
    public class XsdParser
    {
        private static XmlSchema PrepareSchema(string xsdFilePath)
        {
            xsdFilePath.CheckIsValidFilePath();

            XmlSchema schema;
            using (var reader = new StreamReader(xsdFilePath))
            {
                schema = XmlSchema.Read(reader, null);
            }

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(schema);
            schemaSet.Compile();
            schema = schemaSet.Schemas().Cast<XmlSchema>().First();

            return schema;
        }
        public static XDocument GenerateXmlDictionary(string xsdFilePath)
        {
            var frdFile = new XDocument();
            var frdDictionary = new XElement("Dictionary");
            frdFile.Add(frdDictionary);

            var schema = PrepareSchema(xsdFilePath);
            //dataset schema
            var rootElements = schema.Elements.Values.Cast<XmlSchemaElement>();
            var dataSetElement = rootElements.First(e => e.UnhandledAttributes.Any(a => a.Name == "msdata:IsDataSet" && a.Value == "true"));
            if (((XmlSchemaComplexType)dataSetElement.ElementSchemaType).ContentTypeParticle is XmlSchemaChoice sxmlChoise)
            {
                var dataTableElements = sxmlChoise.Items;
                foreach (var dataTable in dataTableElements)
                {
                    var tableName = ((XmlSchemaElement)dataTable).Name;
                    var frdTableDataSource = new XElement("TableDataSource");
                    frdTableDataSource.SetAttributeValue("Name", tableName);
                    frdTableDataSource.SetAttributeValue("ReferenceName", $"{dataSetElement.Name}.{tableName}");
                    frdTableDataSource.SetAttributeValue("Enabled", "true");
                    frdDictionary.Add(frdTableDataSource);

                    if (((XmlSchemaComplexType)((XmlSchemaElement)dataTable).ElementSchemaType).ContentTypeParticle is XmlSchemaSequence xmlSequence)
                    {
                        var dataTableFields = xmlSequence.Items;
                        foreach (var tableField in dataTableFields)
                        {
                            var field = (XmlSchemaElement)tableField;
                            var frdColumn = new XElement("Column");
                            frdColumn.SetAttributeValue("Name", field.Name);
                            frdColumn.SetAttributeValue("DataType", field.ElementSchemaType.Datatype.ValueType.FullName);
                            frdTableDataSource.Add(frdColumn);
                        }
                    }
                }
            }

            //dataset relations
            foreach (var schemaItem in schema.Items)
            {
                if (schemaItem is XmlSchemaAnnotation anotationItem)
                {
                    foreach (var appInfoItem in anotationItem.Items)
                    {
                        if (appInfoItem is XmlSchemaAppInfo appInfo)
                        {
                            foreach (var xmlNode in appInfo.Markup)
                            {
                                if (xmlNode is XmlElement xmlElement && xmlElement.Name == "msdata:Relationship")
                                {
                                    var frdRelation = new XElement("Relation");
                                    frdRelation.SetAttributeValue("Name", xmlElement.Attributes["name"].Value);
                                    frdRelation.SetAttributeValue("ReferenceName", $"{dataSetElement.Name}.{xmlElement.Attributes["name"].Value}");
                                    frdRelation.SetAttributeValue("ParentDataSource", xmlElement.Attributes["msdata:parent"].Value);
                                    frdRelation.SetAttributeValue("ChildDataSource", xmlElement.Attributes["msdata:child"].Value);
                                    frdRelation.SetAttributeValue("ParentColumns", xmlElement.Attributes["msdata:parentkey"].Value);
                                    frdRelation.SetAttributeValue("ChildColumns", xmlElement.Attributes["msdata:childkey"].Value);
                                    frdRelation.SetAttributeValue("Enabled", "true");
                                    frdDictionary.Add(frdRelation);
                                }
                            }
                        }
                    }
                }
            }

            return frdFile;
        }
        public static IEnumerable<Table> GetDataTables(string xsdFilePath)
        {
            var tables = new List<Table>();
            var schema = PrepareSchema(xsdFilePath);

            var rootElements = schema.Elements.Values.Cast<XmlSchemaElement>();
            var dataSetElement = rootElements.First(e => e.UnhandledAttributes.Any(a => a.Name == "msdata:IsDataSet" && a.Value == "true"));
            if (((XmlSchemaComplexType)dataSetElement.ElementSchemaType).ContentTypeParticle is XmlSchemaChoice sxmlChoise)
            {
                var dataTableElements = sxmlChoise.Items;

                foreach (var dataTable in dataTableElements)
                {
                    var tableName = ((XmlSchemaElement)dataTable).Name;
                    var table = new Table
                    {
                        Name = tableName,
                        ReferenceName = $"{dataSetElement.Name}.{tableName}",
                    };

                    if (((XmlSchemaComplexType)((XmlSchemaElement)dataTable).ElementSchemaType).ContentTypeParticle is XmlSchemaSequence xmlSequence)
                    {
                        var dataTableFields = xmlSequence.Items;
                        foreach (var tableField in dataTableFields)
                        {
                            var xField = (XmlSchemaElement)tableField;
                            var field = new Field
                            {
                                Name = xField.Name,
                                DataType = xField.ElementSchemaType.Datatype.ValueType.FullName
                            };
                            table.Fields.Add(field);
                        }
                    }
                    tables.Add(table);
                }
            }

            return tables;
        }

        public static IEnumerable<Relation> GetRelations(string xsdFilePath)
        {
            var relations = new List<Relation>();
            var schema = PrepareSchema(xsdFilePath);

            var rootElements = schema.Elements.Values.Cast<XmlSchemaElement>();
            var dataSetElement = rootElements.First(e => e.UnhandledAttributes.Any(a => a.Name == "msdata:IsDataSet" && a.Value == "true"));

            foreach (var schemaItem in schema.Items)
            {
                if (schemaItem is XmlSchemaAnnotation anotationItem)
                {
                    foreach (var appInfoItem in anotationItem.Items)
                    {
                        if (appInfoItem is XmlSchemaAppInfo appInfo)
                        {
                            foreach (var xmlNode in appInfo.Markup)
                            {
                                if (xmlNode is XmlElement xmlElement && xmlElement.Name == "msdata:Relationship")
                                {
                                    var relation = new Relation
                                    {
                                        Name = xmlElement.Attributes["name"].Value,
                                        ReferenceName = $"{dataSetElement.Name}.{xmlElement.Attributes["name"].Value}",
                                        ParentDataSource = xmlElement.Attributes["msdata:parent"].Value,
                                        ChildDataSource = xmlElement.Attributes["msdata:child"].Value,
                                        ParentColumns = xmlElement.Attributes["msdata:parentkey"].Value,
                                        ChildColumns = xmlElement.Attributes["msdata:childkey"].Value
                                    };
                                    relations.Add(relation);
                                }
                            }
                        }
                    }
                }
            }

            return relations;
        }
    }
}
