using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class CollectionsViewModel : Screen
    {
        public CollectionsViewModel(CollectionsProvider collectionsProvider, ItemListViewModel collectionsViewModel)
        {
            DisplayName = "Collections";
            collectionsViewModel.SetItemsProvider(collectionsProvider);
            Items = collectionsViewModel;

        }
        public ItemListViewModel Items { get; private set; }
    }
}
