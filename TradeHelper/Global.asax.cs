using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using TradeHelper.Infrastructure;

namespace TradeHelper
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer GetContainer()
        {
            return _container ?? (_container = new WindsorContainer().Install(FromAssembly.This()));
        }

        private static void BootstrapContainer()
        {
            var resolver = new WindsorDependencyResolver(GetContainer());
            DependencyResolver.SetResolver(resolver);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorWebApiControllerFactory(GetContainer()));
            //set WebApi DependencyResolver
            var apiResolver = new WindsorApiDependencyResolver(GetContainer());
            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;
        }

        protected void Application_Start()
        {
            BootstrapContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
