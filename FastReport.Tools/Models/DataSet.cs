using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.DictionaryExtension.Models
{
    public class DataSet
    {
        public string Name { get; set; }
        public string FullName { get { return $"{ProjectName} --> {Name}"; } }
        public string ProjectName { get; set; }
        public  string FilePath { get; set; }
    }
}
