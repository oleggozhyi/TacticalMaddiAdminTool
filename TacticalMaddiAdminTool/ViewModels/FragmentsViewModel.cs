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
        public FragmentsViewModel(FragmentsProvider fragments, ItemsViewModel fragmentsViewModel, XmlEditorViewModel xmlEditorViewModel)
        {
            DisplayName = "Fragments";
            fragmentsViewModel.SetItemsProvider(fragments);
            Items = fragmentsViewModel;
            XmlEditor = xmlEditorViewModel;
        }
        public ItemsViewModel Items { get; private set; }
        public XmlEditorViewModel XmlEditor { get; private set; }
    }
}
