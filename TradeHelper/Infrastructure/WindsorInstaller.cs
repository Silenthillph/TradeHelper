using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EntityModel;
using Repository;

namespace TradeHelper.Infrastructure
{
    public class WindsorInstaller: IWindsorInstaller
    {
        #region Implementation of IWindsorInstaller

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<CommonModelContext>().LifestylePerWebRequest());

            #region DbContext Entities registration

            container.Register(Component.For<IDbContext>().ImplementedBy<CommonModelContext>());
                                       // .Named("CommonModelContext"));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork<CommonModelContext>>()
                                        .DependsOn(Dependency.OnComponent(typeof(IDbContext), typeof(CommonModelContext))));
            #endregion

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)));


            #region Controllers registration

            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(IHttpController))
                       .Configure(c => c.LifestylePerWebRequest()));

            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(IController))
                       .Configure(c => c.LifestylePerWebRequest()));

            #endregion
        }

        #endregion
    }
}