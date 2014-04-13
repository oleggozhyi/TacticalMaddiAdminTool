using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.ViewModels;

namespace TacticalMaddiAdminTool.Events
{
    public class SelectedItemChangedEvent
    {
        public ItemViewModel SelectedItem { get; set; }
    }
}
