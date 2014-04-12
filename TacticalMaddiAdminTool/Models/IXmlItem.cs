using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public interface IXmlItem : IItem
    {
        string GetXml();
    }
}
