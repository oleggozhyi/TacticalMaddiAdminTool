using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ConnectionViewModel : PropertyChangedBase
    {
        private string _environment;

        private bool _connected;

        public string Environment
        {
            get { return _environment; }
            set
            {
                if (value == _environment) return;
                _environment = value;
                NotifyOfPropertyChange(() => Environment);
            }
        }

        public void Connect()
        {
            ChangeConnection(true);
        }

        private void ChangeConnection( bool value)
        {
            _connected = value;
            NotifyOfPropertyChange(() => IsConnectVisible);
            NotifyOfPropertyChange(() => IsDisconnectVisible);
        }


        public bool IsConnectVisible
        {
            get { return !_connected; }
          
        }

        public void Disconnect()
        {
            ChangeConnection(false);
        }

        public bool IsDisconnectVisible
        {
            get { return _connected; }
           
        }
    }
}
