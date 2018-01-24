using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace TradeHelper.Infrastructure
{
    public class WindsorWebApiControllerFactory : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorWebApiControllerFactory(IWindsorContainer container)
        {
            this._container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = this._container.Resolve(controllerType);

            return (IHttpController)controller;
        }
    }
}