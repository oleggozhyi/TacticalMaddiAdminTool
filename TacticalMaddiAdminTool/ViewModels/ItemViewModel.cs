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
        public IItem Item { get; private set; }

        public string Title
        {
            get
            {
                return this.Item.Title;
            }
        }
        public Brush IconBackground { get; private set; }
        public string IconSymbol { get; private set; }
        public ItemViewModel(IItem item)
        {
            Item = item;
            if (Item is SetInfo)
            {
                IconSymbol = "s";
                IconBackground = new SolidColorBrush(Colors.DarkGreen);
            }
            else if (Item is CollectionInfo)
            {
                IconSymbol = "c";
                IconBackground = new SolidColorBrush(Colors.Brown);
            }
            else if (Item is FragmentInfo)
            {
                IconSymbol = "f";
                IconBackground = new SolidColorBrush(Colors.Navy);
            }
        }
    }
}
