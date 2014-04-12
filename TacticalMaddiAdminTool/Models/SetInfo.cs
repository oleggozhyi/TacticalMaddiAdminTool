using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class SetInfo : IXmlItem
    {
        public string Title { get { return SetName; } }
        public string SetName { get; set; }
        public string GetXml()
        {
            return String.Format(@"<Set Name='{0}' />", SetName);
        }
    }
}
