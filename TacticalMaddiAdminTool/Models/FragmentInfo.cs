using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class FragmentInfo : IItem
    {
        public string Title { get { return FragmentKey; } }
        public string FragmentKey { get; set; }
        public  virtual string GetXml()
        {
            return "<xxx />";
        }
    }
}
