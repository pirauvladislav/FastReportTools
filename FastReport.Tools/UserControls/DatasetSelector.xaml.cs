using FastReport.DictionaryExtension.Models;
using FastReport.DictionaryExtension.UserControls.ViewModels;
using FastReport.DictionaryExtension.Utils;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FastReport.DictionaryExtension.UserControls
{
    /// <summary>
    /// Interaction logic for DialogSelector.xaml
    /// </summary>
    public partial class DataSetSelector : UserControl
    {
        private DataSetSelectorViewModel _viewModel;
        private string _reportFilePath;
        private DialogWindow _dialogWindow
        {
            get { return this.Parent as DialogWindow; }
        }

        public DataSetSelector()
        {
            InitializeComponent();
            _viewModel = new DataSetSelectorViewModel();
            this.DataContext = _viewModel;
        }

        public DataSetSelector(IEnumerable<DataSet> dataSets, string reportFilePath):this()
        {
            _viewModel.DataSets = dataSets;
            _reportFilePath = reportFilePath;
        }

        private void lbDataSets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] is DataSet selDataSet)
            {
                _viewModel.DataTables = XsdParser.GetDataTables(selDataSet.FilePath);
                _viewModel.Relations = XsdParser.GetRelations(selDataSet.FilePath);
                CollectionView view = CollectionViewSource.GetDefaultView(lbRelations.ItemsSource) as CollectionView;
                view.Filter = obj =>
                {
                    var item = obj as Relation;
                    var selectedtables = lbDataTables.SelectedItems.Cast<Models.Table>(); 
                    if (selectedtables != null)
                        return selectedtables.Where(t => t.Name == item.ParentDataSource).Any() && selectedtables.Where(t => t.Name == item.ChildDataSource).Any();
                    return true;
                };
            }
            else
            {
                _viewModel.DataTables = null;
                _viewModel.Relations = null;
            }
       }

        private void btImport_Click(object sender, RoutedEventArgs e)
        {
            if (lbDataTables.SelectedItems.Count > 0)
            {
                var frxDocumnent = new FrxDocument(_reportFilePath);
                var selectedDataSet = lbDataSets.SelectedItem as DataSet;
                var selectedTables = lbDataTables.SelectedItems.Cast<Models.Table>();
                var relations = lbRelations.SelectedItems.Cast<Relation>();
                frxDocumnent.UpdateDictionary(selectedTables, relations);
            }

            _dialogWindow.Close();
        }

        private void lbDataTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCount = lbDataTables.SelectedItems.Count;
            if (selectedCount > 0)
            {
                btImport.IsEnabled = true;
                if (selectedCount == _viewModel.DataTables.Count())
                    cbSelectAll.IsChecked = true;
                else
                    cbSelectAll.IsChecked = null;
            }
            else
                cbSelectAll.IsChecked = false;

            CollectionViewSource.GetDefaultView(lbRelations.ItemsSource).Refresh();
        }

        private void cbSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            lbDataTables.SelectAll();
        }

        private void cbSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            lbDataTables.UnselectAll();
        }

        private void cbSelectAllRelations_Checked(object sender, RoutedEventArgs e)
        {
            lbRelations.SelectAll();
        }

        private void cbSelectAllRelations_Unchecked(object sender, RoutedEventArgs e)
        {
            lbRelations.UnselectAll();
        }

        private void lbRelations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCount = lbRelations.SelectedItems.Count;
            if (selectedCount > 0)
            {
                if (selectedCount == _viewModel.Relations.Count())
                    cbSelectAllRelations.IsChecked = true;
                else
                    cbSelectAllRelations.IsChecked = null;
            }
            else
                cbSelectAllRelations.IsChecked = false;
        }
    }
}
