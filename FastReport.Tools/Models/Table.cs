using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.DictionaryExtension.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public List<Field> Fields { get; set; }  = new List<Field>();
    }
}
