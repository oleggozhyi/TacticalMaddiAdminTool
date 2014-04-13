using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using TacticalMaddiAdminTool.Events;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class MainContentViewModel: PropertyChangedBase, IHandle<SelectedItemChangedEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly XmlEditorViewModel _xmlEditorViewModel;
        private object _editor;
        public ItemListViewModel ItemList { get; set; }

        public MainContentViewModel(IEventAggregator eventAggregator, ItemListViewModel itemListViewModel, XmlEditorViewModel xmlEditorViewModel)
        {
            _eventAggregator = eventAggregator;
            _xmlEditorViewModel = xmlEditorViewModel;
            _eventAggregator.Subscribe(this);
            ItemList = itemListViewModel;
        }

        public void Handle(SelectedItemChangedEvent message)
        {
            if (message.SelectedItem == null)
            {
                Editor = null;
                return;
            }
            _xmlEditorViewModel.SetItem(message.SelectedItem);
            Editor = null;
            Editor = _xmlEditorViewModel;
        }

        public object Editor
        {
            get { return _editor; }
            set
            {
                if (Equals(value, _editor)) return;
                _editor = value;
                NotifyOfPropertyChange(() => Editor);
            }
        }
    }
}
