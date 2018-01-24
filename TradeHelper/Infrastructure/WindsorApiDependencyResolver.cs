using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace TradeHelper.Infrastructure
{
    public class WindsorApiDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorApiDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this._container = container;
        }

        public object GetService(Type t)
        {
            return this._container.Kernel.HasComponent(t) ? this._container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return this._container.ResolveAll(t).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorApiDependencyScope(this._container);
        }

        public void Dispose()
        {
        }
    }
}