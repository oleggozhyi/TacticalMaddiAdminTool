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
        public CollectionsViewModel(CollectionsProvider collectionsProvider, ItemsViewModel collectionsViewModel, XmlEditorViewModel xmlEditorViewModel)
        {
            DisplayName = "Collections";
            collectionsViewModel.SetItemsProvider(collectionsProvider);
            Items = collectionsViewModel;
            Editor = xmlEditorViewModel;
        }
        public ItemsViewModel Items { get; private set; }
        public XmlEditorViewModel Editor { get; private set; }
    }
}
