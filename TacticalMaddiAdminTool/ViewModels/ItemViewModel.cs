using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemViewModel
    {
        public IItem Item { get; private set; }
        public string Title { get { return this.Item.Title; } }
        public ItemViewModel(IItem item)
        {
            Item = item;
        }
    }
}
