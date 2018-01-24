using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace TradeHelper.Infrastructure
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        internal readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            return this._container.Kernel.HasComponent(serviceType)
                ? this._container.Resolve(serviceType)
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._container.Kernel.HasComponent(serviceType)
                ? this._container.ResolveAll(serviceType).Cast<object>()
                : new object[] { };
        }
    }
}