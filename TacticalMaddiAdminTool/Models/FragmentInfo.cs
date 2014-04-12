using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.Models
{
    public class FragmentInfo : IXmlItem
    {
        public string Title { get { return FragmentKey; } }
        public string FragmentKey { get; set; }
        public  virtual string GetXml()
        {
            return String.Format(
@"<Fragment SnappingType='Mapping' Key='{0}'>
    <Mapping>
        <Item Key='key1' Value='value1' />
        <Item Key='key2' Value='value2' />
    </Mapping>
</Fragment>", FragmentKey);
        }
    }
}
