using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class CollectionInfo : IXmlItem
    {
        public string Title { get { return ColectionKey; } }
        public string ColectionKey { get; set; }
        public string GetXml()
        {
            return String.Format(
@"<Collection Key='{0}'>
    <Fragment Key='a1/b1/c1/d1' />
    <Fragment Key='a1/b1/c1/d1' />
</Collection>", ColectionKey);
        }
    }
}
