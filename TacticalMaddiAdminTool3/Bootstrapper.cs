using System.Linq;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using TacticalMaddiAdminTool.Infrastructure;
using TacticalMaddiAdminTool.Services;
using TacticalMaddiAdminTool.ViewModels;

namespace TacticalMaddiAdminTool
{
    public class Bootstrapper : BootstrapperBase
    {
        public static Bootstrapper Current { get; private set; }
        public IEventAggregator EventAggregator
        {
            get { return GetAllInstances(typeof(IEventAggregator)).Cast<IEventAggregator>().First(); }
        }

        SimpleContainer container;

        public Bootstrapper()
        {
            Start();
            Current = this;
        }

        protected override void Configure()
        {

            LogManager.GetLog = type => new DebugLogger(type);

            container = new SimpleContainer();

            // Services
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();

            container.Singleton<ItemsProvider>();
            //container.Singleton<FragmentsProvider>();
            //container.Singleton<SetsProvider>();
            //container.Singleton<CollectionsProvider>();

            //ViewModels
            container.PerRequest<MainViewModel>();
            container.PerRequest<ItemListViewModel>();
            container.PerRequest<ConnectionViewModel>();
            container.PerRequest<ConnectViewModel>();

            //container.PerRequest<SetsViewModel>();
            //container.PerRequest<ItemsViewModel>();
            //container.PerRequest<XmlEditorViewModel>();

        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
