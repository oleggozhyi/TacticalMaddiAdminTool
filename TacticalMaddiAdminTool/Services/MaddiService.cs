using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Services
{
    public class MaddiService : TacticalMaddiAdminTool.Services.IMaddiService
    {
        public void Save(string entityXml)
        {
        }

        public SetInfo[] GetSets()
        {
            return new SetInfo[0];
        }
        public CollectionInfo[] GetCollections()
        {
            return new CollectionInfo[0];
        }
        public FragmentInfo[] GetFragments()
        {
            return new FragmentInfo[0];
        }
    }
}
