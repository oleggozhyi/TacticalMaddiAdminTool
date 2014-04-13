using System.Windows;
using Caliburn.Micro;
using TacticalMaddiAdminTool.Events;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class MainViewModel : Screen, IHandle<ConnectedEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ConnectViewModel _connectViewModel;
        private object _content;
        private string _connectionStatus;
        public ItemListViewModel Items { get; set; }
        public ConnectionViewModel Connection { get; set; }

        public MainViewModel(IEventAggregator eventAggregator,
                            ItemListViewModel itemListViewModel,
                            ConnectionViewModel connection,
                            ConnectViewModel connectViewModel)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _connectViewModel = connectViewModel;
            Items = itemListViewModel;
            Connection = connection;
            Content = _connectViewModel;
            DisplayName = "MaDDI Administation Tool";
        }


        public void Disconnect()
        {
            _eventAggregator.Publish(new DisconnectEvent());
            ConnectionStatus = null;
            Content = _connectViewModel;
        }

        public bool ShowDisconnect
        {
            get { return ConnectionStatus != null; }
        }

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                if (value == _connectionStatus) return;
                _connectionStatus = value;
                NotifyOfPropertyChange(() => ConnectionStatus);
                NotifyOfPropertyChange(() => ShowDisconnect);
            }
        }

        public object Content
        {
            get { return _content; }
            set
            {
                if (Equals(value, _content)) return;
                _content = value;
                NotifyOfPropertyChange(() => Content);
            }
        }

        public void Handle(ConnectedEvent message)
        {
            ConnectionStatus = "Connected to " + message.Environment.ToUpper();
            Content = Items;
        }
    }
}