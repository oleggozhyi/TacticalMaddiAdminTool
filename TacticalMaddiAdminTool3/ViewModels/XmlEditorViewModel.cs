using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class XmlEditorViewModel : PropertyChangedBase
    {
        private string _xml;
        private ItemViewModel _selectedItem;

        public void SetItem(ItemViewModel itemViewModel)
        {
            Xml = GetXml(itemViewModel);
            SelectedItem = itemViewModel;
        }

        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        public string Xml
        {
            get { return _xml; }
            set
            {
                if (value == _xml) return;
                _xml = value;
                NotifyOfPropertyChange(() => Xml);
            }
        }

        private string GetXml(ItemViewModel itemViewModel)
        {
            return String.Format("<--Item Title = {0}-->", itemViewModel.Title) +
                @"
<messages>
   <note id='501'>
     <to>Tove</to>
     <from>Jani</from>
     <heading>Reminder</heading>
     <body>Don't forget me this weekend!</body>
   </note>
   <note id='502'>
     <to>Jani</to>
     <from>Tove</from>
     <heading>Re: Reminder</heading>
     <body>I will not</body>
   </note>
 </messages>";

        }
    }
}
