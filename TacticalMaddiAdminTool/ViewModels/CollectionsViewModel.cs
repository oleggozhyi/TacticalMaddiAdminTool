using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
   public class CollectionsViewModel : Screen
    {
        public CollectionsViewModel()
        {
            DisplayName = "Collections";
        }
        public string Message { get { return "Collections"; } }
    }
}
