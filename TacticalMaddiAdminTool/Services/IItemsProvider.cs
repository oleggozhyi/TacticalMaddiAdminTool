using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Services
{
    public interface IItemsProvider
    {
        Task<IItem[]> GetItemsAsync();
    }

    public abstract class ItemsProvider : IItemsProvider
    {
        protected IMaddiService maddiService;

        public ItemsProvider(IMaddiService maddiService)
        {
            this.maddiService = maddiService;
        }
        protected abstract Func<IItem[]> GetItemsFunction { get; }

        public Task<IItem[]> GetItemsAsync()
        {
            return Task.Factory.StartNew(_ => GetItemsFunction(), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

    public class SetsProvider : ItemsProvider
    {
        protected override Func<IItem[]> GetItemsFunction { get { return maddiService.GetSets; } }
    }
    public class FragmentsProvider : ItemsProvider
    {
        protected override Func<IItem[]> GetItemsFunction { get { return maddiService.GetFragments; } }
    }
    public class CollectionsProvider : ItemsProvider
    {
        protected override Func<IItem[]> GetItemsFunction { get { return maddiService.GetCollections; } }
    }
}
