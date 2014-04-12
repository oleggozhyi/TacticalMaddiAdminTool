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
        private IEventAggregator eventAggregator;

        public ItemListViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
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


        private void ApplySearchCriteria()
        {
            throw new NotImplementedException();
        }

    }
}
