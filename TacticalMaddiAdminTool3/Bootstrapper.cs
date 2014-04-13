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
        SimpleContainer container;

        public Bootstrapper()
        {
            Start();
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
