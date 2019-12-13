using Autofac;
using GroceryExpressCart.Core.Repository;
using System.Reflection;
using Module = Autofac.Module;

namespace GroceryExpressCart.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(asign => asign.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
