using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public MainViewModel(SetsViewModel setsViewModel, CollectionsViewModel collectionsViewModel, FragmentsViewModel fragmentsViewModel)
        {
            Items.Add(fragmentsViewModel);
            Items.Add(collectionsViewModel);
            Items.Add(setsViewModel);

            ActivateItem(fragmentsViewModel);
        }
    }
}
