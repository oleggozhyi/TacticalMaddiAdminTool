using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using TacticalMaddiAdminTool.Events;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ConnectViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _environment;
        private bool _isConnecting;


        public ConnectViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            set
            {
                if (value.Equals(_isConnecting)) return;
                _isConnecting = value;
                NotifyOfPropertyChange(() => IsConnecting);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public string Environment
        {
            get { return _environment; }
            set
            {
                if (value == _environment) return;
                _environment = value;
                NotifyOfPropertyChange(() => Environment);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public void Connect()
        {
            IsConnecting = true;

            TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var connectionTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                if (Environment == "throw")
                    throw new Exception("Cannot connect to Maddi - user is invalid");
            });
            connectionTask.ContinueWith(t =>
            {
                IsConnecting = false;
                _eventAggregator.Publish(new ConnectedEvent { Environment = Environment });
            }, default(CancellationToken), TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);

            connectionTask.ContinueWith(t =>
            {
                IsConnecting = false;
                _eventAggregator.Publish(new ShowMessageEvent { Title = "ERROR", Message = t.Exception.InnerException.Message, Exception = t.Exception.InnerException });
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public bool CanConnect
        {
            get { return !_isConnecting && !String.IsNullOrWhiteSpace(Environment); }
        }
    }
}
