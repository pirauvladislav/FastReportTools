using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using FastReport.DictionaryExtension.Models;
using Microsoft.VisualStudio.Shell;

namespace FastReport.DictionaryExtension.Utils
{
    internal class SolutionExplorer
    {
        private AsyncPackage _package;
        private EnvDTE80.DTE2 _dte2;

        public EnvDTE80.DTE2 GetDTE2()
        {
            if (_dte2 == null)
            {
                 _dte2 = _package.GetServiceAsync(typeof(DTE)).Result as EnvDTE80.DTE2;
            }
            return _dte2;
        }

        public SolutionExplorer(AsyncPackage package)
        {
            this._package = package;
        }

        public string GetSelectedFilePath()
        {
            var _applicationObject = GetDTE2();
            UIHierarchy uih = _applicationObject.ToolWindows.SolutionExplorer;

            ThreadHelper.ThrowIfNotOnUIThread();
            Array selectedItems = (Array)uih.SelectedItems;
            if (selectedItems != null)
            {
                foreach (UIHierarchyItem selItem in selectedItems)
                {
                    ProjectItem prjItem = selItem.Object as ProjectItem;
                    return prjItem.Properties.Item("FullPath").Value.ToString();
                }
            }
            return string.Empty;
        }

        public IEnumerable<DataSet> GetSolutionDataSets()
        {
            var _applicationObject = GetDTE2();
            var solution = _applicationObject.Solution;

            ThreadHelper.ThrowIfNotOnUIThread();
            var dataSets = new List<DataSet>();
            for (int i = 1; i <= solution.Projects.Count; i++)
            {
                var proj = solution.Projects.Item(i);
                dataSets.AddRange(GetProjectDataSets(proj.ProjectItems));
            }
            return dataSets;

        }

        private IEnumerable<DataSet> GetProjectDataSets(ProjectItems items)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dataSets = new List<DataSet>();
            for (int i = 1; i <= items.Count; i++)
            {
                var item = items.Item(i);
                if (item.ProjectItems.Count > 0)
                {
                    dataSets.AddRange(GetProjectDataSets(item.ProjectItems));
                }
                if (item.Name.EndsWith(".xsd"))
                {
                    dataSets.Add(new DataSet { Name = item.Name, FilePath = item.FileNames[0], ProjectName = item.ContainingProject.Name });
                }
            }
            return dataSets;
        }
    }
}
