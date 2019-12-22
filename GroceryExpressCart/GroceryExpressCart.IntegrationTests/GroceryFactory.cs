using Autofac.Extensions.DependencyInjection;
using GroceryExpressCart.API;
using GroceryExpressCart.Common.Logs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GroceryExpressCart.IntegrationTests
{
    public class GroceryFactory : WebApplicationFactory<GroceryFactory>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().UseLoging()
              .UseServiceProviderFactory(new AutofacServiceProviderFactory()).
              UseContentRoot(Directory.GetCurrentDirectory()).
              ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().
              UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").
              Build()));
        }
    }
}
