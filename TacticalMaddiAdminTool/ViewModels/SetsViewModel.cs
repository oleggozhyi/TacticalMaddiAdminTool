using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Services;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class SetsViewModel : Screen
    {
        public SetsViewModel(SetsProvider setsProvider, ItemsViewModel setsViewModel)
        {
            DisplayName = "Sets";
            setsViewModel.SetItemsProvider(setsProvider);
            Items = setsViewModel;
        }
        public ItemsViewModel Items { get; private set; }
    }
}
