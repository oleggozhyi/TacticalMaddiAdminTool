using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TacticalMaddiAdminTool.Events;
using TacticalMaddiAdminTool.Models;

namespace TacticalMaddiAdminTool.ViewModels
{
    public class XmlEditorViewModel : PropertyChangedBase, IHandle<OpenItemEvent>
    {
        private IEventAggregator eventAggregator;
        private string xml;

        public XmlEditorViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

        public void Handle(OpenItemEvent message)
        {
            var xmlItem = message.Item as IXmlItem;
            Debug.Assert(xmlItem != null);
            Xml = xmlItem.GetXml();
        }

        public string Xml
        {
            get { return xml; }
            set
            {
                xml = value;
                NotifyOfPropertyChange(() => Xml);
            }
        }
    }
}
