using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Events
{
    public class OpenItemEvent
    {
        public IItem Item { get; set; }
    }
}
