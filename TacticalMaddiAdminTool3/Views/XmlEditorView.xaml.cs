using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.Highlighting;

namespace TacticalMaddiAdminTool.Views
{
    /// <summary>
    /// Interaction logic for XmlEditorView.xaml
    /// </summary>
    public partial class XmlEditorView : UserControl
    {
        public XmlEditorView()
        {
            InitializeComponent();
        }

        private void XmlEditorView_OnLoaded(object sender, RoutedEventArgs e)
        {
            XmlTextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");
        }
    }
}
