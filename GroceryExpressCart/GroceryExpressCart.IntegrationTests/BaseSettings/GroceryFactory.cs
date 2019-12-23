using Autofac.Extensions.DependencyInjection;
using GroceryExpressCart.API;
using GroceryExpressCart.Common.Loging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace GroceryExpressCart.IntegrationTests.BaseSettings
{
    public class GroceryFactory : WebApplicationFactory<GroceryFactory>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().UseLoging()
              .UseServiceProviderFactory(new AutofacServiceProviderFactory()).
              UseContentRoot(Directory.GetCurrentDirectory()).
              ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().
              UseConfiguration(new ConfigurationBuilder().AddJsonFile("BaseSettings\\appTestsettings.json").
              Build()));
        }
        public static StringContent GetPayload(object source)
        {
            if (source is null)
                throw new ArgumentException(nameof(source));
            var json = JsonConvert.SerializeObject(source);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
