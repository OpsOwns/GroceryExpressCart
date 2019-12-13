using Autofac;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Common.Settings;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace GroceryExpressCart.Infrastructure.IoC.Modules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration) =>
            _configuration = configuration;
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetOptions<DatabaseSettings>("GroceryDB")).
                SingleInstance();
            builder.RegisterInstance(_configuration.GetOptions<PasswordSettings>("Security"))
                .SingleInstance();
        }
    }
}
