using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Events
{
    public class ShowMessageEvent
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
