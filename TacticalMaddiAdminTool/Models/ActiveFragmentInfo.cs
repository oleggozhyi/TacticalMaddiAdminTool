﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class ActiveFragmentInfo : FragmentInfo, IItem
    {
        public override string GetXml()
        {
            throw new NotSupportedException();
        }
    }
}
