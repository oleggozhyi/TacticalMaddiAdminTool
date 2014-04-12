using System;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.Services
{
    public interface IMaddiService
    {
        CollectionInfo[] GetCollections();
        FragmentInfo[] GetFragments();
        SetInfo[] GetSets();
        void Save(string entityXml);
    }
}
