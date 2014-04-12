using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Services
{
    public class FakeMaddiService :IMaddiService
    {

        public void Save(string entityXml)
        {
        }

        public SetInfo[] GetSets()
        {
            return new[] 
            {
                new SetInfo { SetName = "LdnCLose" }, new SetInfo { SetName = "Test" }
            };

        }
        public CollectionInfo[] GetCollections()
        {
            return new[] 
            {
                new CollectionInfo { ColectionKey = "Bank/Default/Collections/Collection1" },
                new CollectionInfo { ColectionKey = "Bank/Default/Collections/Collection2" },
                new CollectionInfo { ColectionKey = "Bank/Default/Collections/Collection3" },
            };
        }
        public FragmentInfo[] GetFragments()
        {
            return new[] 
            {
                new FragmentInfo { FragmentKey = "Bank/Default/Fragment/Fragment1" },
                new FragmentInfo { FragmentKey = "Bank/Default/Fragment/Fragment2" },
                new FragmentInfo { FragmentKey = "Bank/Default/Fragment/Fragment3" },
            };
        }

    }
}
