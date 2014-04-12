using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class FragmentsViewModel : Screen
    {
        public FragmentsViewModel()
        {
            DisplayName = "Fragments";
        }
        public string Message { get { return "Fragments"; } }

    }
}
