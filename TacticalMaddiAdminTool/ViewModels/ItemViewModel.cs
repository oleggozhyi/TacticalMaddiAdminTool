using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemViewModel
    {
        public ItemViewModel(IItem item)
        {
            Item = item;
        }
        public IItem Item { get; private set; }
        public string Title { get { return this.Item.Title; } }
        public Brush IconBackground { get; private set; }
        public string IconSymbol { get; private set; }
    }
}
