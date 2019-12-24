using FastReport.DictionaryExtension.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FastReport.DictionaryExtension.UserControls.ViewModels
{
    public class DataSetSelectorViewModel : INotifyPropertyChanged
    {
        private IEnumerable<DataSet> _dataSets;
        private IEnumerable<Table> _dataTable;
        private IEnumerable<Relation> _relations;
        public IEnumerable<DataSet> DataSets
        {
            get { return _dataSets; }
            set
            {
                _dataSets = value;
                OnPropertyChanged();
            }
        }
        public IEnumerable<Table> DataTables
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Relation> Relations
        {
            get { return _relations; }
            set
            {
                _relations = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
