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
using System.Windows.Shapes;
using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Highlighting;
using MahApps.Metro.Controls.Dialogs;
using TacticalMaddiAdminTool.Events;

namespace TacticalMaddiAdminTool.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : IHandle<ShowMessageEvent>
    {
        public MainView()
        {
            InitializeComponent();
            IEventAggregator eventAggregator = Bootstrapper.Current.EventAggregator;
            eventAggregator.Subscribe(this);
        }

        public void Handle(ShowMessageEvent message)
        {
            MessageBox.Show(this, message.Message, message.Title, MessageBoxButton.OK,
                message.Exception != null ? MessageBoxImage.Error : MessageBoxImage.Information);
        }
    }
}
