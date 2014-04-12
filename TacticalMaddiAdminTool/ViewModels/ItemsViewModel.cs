using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticalMaddiAdminTool.Events;
using TacticalMaddiAdminTool.Models;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemsViewModel : PropertyChangedBase
    {
        private string searchCriterria;
        private IEventAggregator eventAggregator;
        private ItemsProvider itemsProvider;
        private List<ItemViewModel> items;

        public ItemsViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public List<ItemViewModel> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        public string SearchCriterria
        {
            get { return this.searchCriterria; }
            set
            {
                if (this.searchCriterria == value)
                    return;

                this.SearchCriterria = value;
                NotifyOfPropertyChange(() => SearchCriterria);
                ApplySearchCriteria();
            }
        }

        public void SetItemsProvider(ItemsProvider itemsProvider)
        {
            this.itemsProvider = itemsProvider;
            UpdateItems();
        }

        private void UpdateItems()
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            this.itemsProvider.GetItemsAsync().ContinueWith(t => SyncItems(t.Result), scheduler);
        }

        private void SyncItems(IItem[] items)
        {
            Items = items.Select(i => new ItemViewModel(i)).ToList();
        }

        private void ApplySearchCriteria()
        {
            throw new NotImplementedException();
        }

        public void OpenForEdit(ItemViewModel itemVm)
        {
            this.eventAggregator.Publish(new OpenItemEvent { Item = itemVm.Item });
        }
    }
}
