using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class CollectionInfo : IItem
    {
        public string Title { get { return ColectionKey; } }
        public string ColectionKey { get; set; }
        public string GetXml()
        {
            return "<xxx />";
        }
    }
}
