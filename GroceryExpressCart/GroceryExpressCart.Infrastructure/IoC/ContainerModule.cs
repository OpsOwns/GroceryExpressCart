using Autofac;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Infrastructure.IoC.Modules;
using GroceryExpressCart.Infrastructure.Mapper;
using Microsoft.Extensions.Configuration;

namespace GroceryExpressCart.Infrastructure.IoC
{
    public class ContainerModule : Module
    {
        private readonly IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration) =>
            _configuration = configuration;
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().InstancePerLifetimeScope();
            builder.RegisterModule<EventModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MediatrModule>();
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
