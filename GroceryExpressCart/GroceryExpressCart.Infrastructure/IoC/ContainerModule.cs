using Autofac;
using GroceryExpressCart.Infrastructure.IoC.Modules;
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
            builder.RegisterModule<EventModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<RepositoryModule>();
        }
    }
}
