using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemViewModel 
    {
        public string Title { get; set; }
        public string ItemType { get; set; }
        public IItem Item { get; set; }
    }

    public interface IItem
    {

    }
}
