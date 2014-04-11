using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class MainViewModel : Caliburn.Micro.PropertyChangedBase
    {
        public MainViewModel()
        {
            Message = "Hello world";
        }
        public string Message { get; set; }
    }
}
