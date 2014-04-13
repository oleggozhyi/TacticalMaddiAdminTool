using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using TacticalMaddiAdminTool.Events;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemListViewModel : PropertyChangedBase, IHandle<ConnectedEvent>, IHandle<DisconnectEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ItemsProvider _itemsProvider;
        private string _filter;
        private ICollectionView _items;
        private ItemViewModel _selectedItem;

        public ItemListViewModel(IEventAggregator eventAggregator, ItemsProvider itemsProvider)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _itemsProvider = itemsProvider;
        }

        private void LoadItems()
        {
            TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Task<ItemViewModel[]> loadItems = Task.Factory.StartNew(() => _itemsProvider.LoadItems());
            loadItems.ContinueWith(t =>
            {
                Items = CollectionViewSource.GetDefaultView(t.Result);
                Items.GroupDescriptions.Add(new PropertyGroupDescription("ItemType"));
                Items.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
                Items.Filter =
                    s =>
                        Filter == null || Filter.Length <= 2 ||
                        ((ItemViewModel)s).Title.ToUpper().Contains(Filter.ToUpper());
            }, default(CancellationToken), TaskContinuationOptions.OnlyOnRanToCompletion, scheduler);
            loadItems.ContinueWith(t =>
            {
                _eventAggregator.Publish(new ShowMessageEvent { Title = "ERROR", Message = t.Exception.InnerException.Message, Exception = t.Exception.InnerException });
            }, default(CancellationToken), TaskContinuationOptions.OnlyOnFaulted, scheduler);
        }

        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                _eventAggregator.Publish(new SelectedItemChangedEvent { SelectedItem = _selectedItem });
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter) return;
                _filter = value;
                Items.Refresh();
                NotifyOfPropertyChange(() => Filter);
            }
        }

        public ICollectionView Items
        {
            get { return _items; }
            set
            {
                if (Equals(value, _items)) return;
                _items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        public void Handle(ConnectedEvent message)
        {
            LoadItems();
        }

        public void Handle(DisconnectEvent message)
        {
            Items = null;
        }
    }
}
