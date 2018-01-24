using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace TradeHelper.Infrastructure
{
    public class WindsorApiDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorApiDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this._container = container;
            this._scope = container.BeginScope();
        }

        public object GetService(Type t)
        {
            return this._container.Kernel.HasComponent(t) ? this._container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return this._container.ResolveAll(t).Cast<object>().ToArray();
        }

        public void Dispose()
        {
            this._scope.Dispose();
        }
    }
}