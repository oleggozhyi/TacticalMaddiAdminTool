using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class FragmentsViewModel : Screen
    {
        public FragmentsViewModel(FragmentsProvider fragments, ItemsViewModel fragmentsViewModel)
        {
            DisplayName = "Fragments";
            fragmentsViewModel.SetItemsProvider(fragments);
            Items = fragmentsViewModel;
        }
        public ItemsViewModel Items { get; private set; }
    }
}
