using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class ItemListViewModel : PropertyChangedBase
    {
        private string searchCriterria;

        public ItemListViewModel()
        { 
        }


        public string SearchCriterria
        {
            get { return this.searchCriterria; }
            set
            {
                if (this.searchCriterria == value)
                    return;

                this.SearchCriterria = value;
                NotifyOfPropertyChange(() => SearchCriterria);
                ApplySearchCriteria();
            }
        }

        public ObservableCollection<string> Items { get;  }

        private void ApplySearchCriteria()
        {
            throw new NotImplementedException();
        }

    }
}
