using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Models;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemListViewModel : PropertyChangedBase
    {
        private string searchCriterria;
        private IEventAggregator eventAggregator;
        private IItemsProvider itemsProvider;

        public ItemListViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void SetItemsProvider(IItemsProvider itemsProvider)
        {
            this.itemsProvider = itemsProvider;
            UpdateItems();
        }

        private void UpdateItems()
        {
            this.itemsProvider.GetItemsAsync().ContinueWith(t => SyncItems(t.Result));
        }

        private void SyncItems(IItem[] items)
        {
            Items = items.Select(i => new ItemViewModel(i)).ToList();
        }

        public List<ItemViewModel> Items { get; set; }

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


        private void ApplySearchCriteria()
        {
            throw new NotImplementedException();
        }

    }
}
