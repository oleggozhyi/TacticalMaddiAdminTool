using System;
using TacticalMaddiAdminTool.Models;
namespace TacticalMaddiAdminTool.Services
{
    interface IMaddiService
    {
        CollectionInfo[] GetCollections();
        FragmentInfo[] GetFragments();
        SetInfo[] GetSets();
        void Save(string entityXml);
    }
}
