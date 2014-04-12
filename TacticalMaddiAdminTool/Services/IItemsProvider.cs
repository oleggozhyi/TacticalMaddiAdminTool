using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Services
{
    public abstract class ItemsProvider
    {
        protected IMaddiService maddiService;
        protected Func<IItem[]> getItemsFunction;

        public ItemsProvider(IMaddiService maddiService)
        {
            this.maddiService = maddiService;
        }

        public Task<IItem[]> GetItemsAsync()
        {
            return Task.Factory.StartNew(getItemsFunction);
        }
    }

    public class SetsProvider : ItemsProvider
    {
        public SetsProvider(IMaddiService maddiService) : base(maddiService)
        {
            getItemsFunction = maddiService.GetSets;
        }
    }
    public class FragmentsProvider : ItemsProvider
    {
        public FragmentsProvider(IMaddiService maddiService) : base(maddiService)
        {
            getItemsFunction = maddiService.GetFragments;
        }
    }

    public class CollectionsProvider : ItemsProvider
    {
        public CollectionsProvider(IMaddiService maddiService) : base(maddiService)
        {
            getItemsFunction = maddiService.GetCollections;
        }
    }
   
}
