using Autofac;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Domain;
using System.Reflection;
using Module = Autofac.Module;

namespace GroceryExpressCart.Infrastructure.IoC.Modules
{
    public class EventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EventModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                          .AsClosedTypesOf(typeof(IDomainEventHandler<>))
                          .InstancePerLifetimeScope();

            builder.RegisterType<DomainEventDispatcher>()
                    .As<IDomainEventDispatcher>()
                    .InstancePerLifetimeScope();

            var assemblySecond = typeof(EventModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assemblySecond).Where(asign => asign.IsAssignableTo<IDomainEvent>())
              .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
