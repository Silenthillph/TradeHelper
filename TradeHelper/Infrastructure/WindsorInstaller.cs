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
using TradeHelper.Cqrs;
using TradeHelper.Cqrs.Command.Interfaces;
using TradeHelper.Cqrs.Query.Interfaces;

namespace TradeHelper.Infrastructure
{
    public class WindsorInstaller: IWindsorInstaller
    {
        #region Implementation of IWindsorInstaller

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IQueryDispatcher>().ImplementedBy<QueryDispatcher>().LifestyleSingleton());
            container.Register(Component.For<ICommandDispatcher>().ImplementedBy<CommandDispatcher>().LifestyleSingleton());

            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(ICommandHandler<>))
                       .If(f => f.Namespace.Contains("TradeHelper.Cqrs.Command"))
                       .Configure(d => d.DependsOn(Dependency.OnComponent("unitOfWork", "UnitOfWork"))));

            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn(typeof(IQueryHandler<,>))
                       .If(f => f.Namespace.Contains("TradeHelper.Cqrs.Query"))
                       .Configure(d => d.DependsOn(Dependency.OnComponent("unitOfWork", "UnitOfWork"))));

            #region DbContext Entities registration

            container.Register(Component.For<IDbContext>().ImplementedBy<CommonModelContext>());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork<CommonModelContext>>()
                                        .DependsOn(Dependency.OnComponent(typeof(IDbContext), typeof(CommonModelContext)))
                                        .Named("UnitOfWork"));
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