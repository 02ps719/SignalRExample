using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using SignalR;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Core
{
    public class StructureMapResolver : DefaultDependencyResolver
    {
        
        private readonly IContainer _container;

        public StructureMapResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            return !serviceType.IsAbstract && !serviceType.IsInterface && serviceType.IsClass
                                 ? _container.GetInstance(serviceType)
                                 : (_container.TryGetInstance(serviceType) ?? base.GetService(serviceType));
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>().Concat(base.GetServices(serviceType));
        }
    }

    public class SignalRRegistry : Registry
    {
        public SignalRRegistry()
        {
            For<IDependencyResolver>().Singleton().Add<StructureMapResolver>();
        }

        public void Configure()
        {
            GlobalHost.DependencyResolver = ObjectFactory.GetInstance<IDependencyResolver>();
            RouteTable.Routes.MapHubs();
        }
    }
}