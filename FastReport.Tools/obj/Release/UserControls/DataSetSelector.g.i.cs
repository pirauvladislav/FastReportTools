﻿#pragma checksum "..\..\..\UserControls\DataSetSelector.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4034D78FA0365B9E4334F382C50866547AACFD2D1160205518A3E18915FD64DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FastReport.DictionaryExtension.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FastReport.DictionaryExtension.UserControls {
    
    
    /// <summary>
    /// DataSetSelector
    /// </summary>
    public partial class DataSetSelector : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbDataSets;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbDataTables;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSelectAll;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbRelations;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btImport;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UserControls\DataSetSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSelectAllRelations;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FastReport.Tools;component/usercontrols/datasetselector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\DataSetSelector.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbDataSets = ((System.Windows.Controls.ListBox)(target));
            
            #line 20 "..\..\..\UserControls\DataSetSelector.xaml"
            this.lbDataSets.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbDataSets_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbDataTables = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\..\UserControls\DataSetSelector.xaml"
            this.lbDataTables.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbDataTables_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbSelectAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 47 "..\..\..\UserControls\DataSetSelector.xaml"
            this.cbSelectAll.Checked += new System.Windows.RoutedEventHandler(this.cbSelectAll_Checked);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\UserControls\DataSetSelector.xaml"
            this.cbSelectAll.Unchecked += new System.Windows.RoutedEventHandler(this.cbSelectAll_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbRelations = ((System.Windows.Controls.ListBox)(target));
            
            #line 49 "..\..\..\UserControls\DataSetSelector.xaml"
            this.lbRelations.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbRelations_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btImport = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\UserControls\DataSetSelector.xaml"
            this.btImport.Click += new System.Windows.RoutedEventHandler(this.btImport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbSelectAllRelations = ((System.Windows.Controls.CheckBox)(target));
            
            #line 68 "..\..\..\UserControls\DataSetSelector.xaml"
            this.cbSelectAllRelations.Checked += new System.Windows.RoutedEventHandler(this.cbSelectAllRelations_Checked);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\UserControls\DataSetSelector.xaml"
            this.cbSelectAllRelations.Unchecked += new System.Windows.RoutedEventHandler(this.cbSelectAllRelations_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

