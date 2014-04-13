using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Caliburn.Micro;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
   public class ItemListViewModel : PropertyChangedBase
    {
       private readonly ItemsProvider _itemsProvider;
       private string _filter;


       public ItemListViewModel(ItemsProvider itemsProvider)
       {
           _itemsProvider = itemsProvider;
           LoadItems();
       }

       private void LoadItems()
       {
           ItemViewModel[] itemViewModels = _itemsProvider.LoadItems();
           Items = CollectionViewSource.GetDefaultView(itemViewModels);
           Items.GroupDescriptions.Add(new PropertyGroupDescription("ItemType"));
           Items.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
           Items.Filter = s => Filter == null || Filter.Length <= 2 || ((ItemViewModel)s).Title.ToUpper().Contains(Filter.ToUpper());
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

       public ICollectionView Items { get; set; }
    }
}
