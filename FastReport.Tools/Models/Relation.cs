using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.DictionaryExtension.Models
{
    public class Relation
    {
        public string Name { get; set; }
        public string FullName
        {
            get
            {
                return $"{ParentDataSource}[{ParentColumns}] --> {ChildDataSource}[{ChildColumns}]";
            }
        }
        public string ReferenceName { get; set; }
        public string ParentDataSource { get; set; }
        public string ChildDataSource { get; set; }
        public string ParentColumns { get; set; }
        public string ChildColumns { get; set; }
    }
}
