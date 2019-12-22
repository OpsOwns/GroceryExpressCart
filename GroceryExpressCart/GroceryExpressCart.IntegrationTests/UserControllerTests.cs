using Autofac.Extensions.DependencyInjection;
using FluentAssertions;
using GroceryExpressCart.API;
using GroceryExpressCart.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using GroceryExpressCart.Common.Logs;
using Microsoft.Extensions.Hosting;

namespace GroceryExpressCart.IntegrationTests
{
    public class UserControllerTests
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;
        public UserControllerTests()
        {
            var t = Host.CreateDefaultBuilder().UseLoging();

            _server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseContentRoot(Directory.GetCurrentDirectory()).ConfigureServices(x => x.AddAutofac(_ => new AutofacServiceProviderFactory())).
                UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()).UseStartup<Startup>());
             _client = _server.CreateClient();
        }
        [Fact]
        public async Task CreateUserTest()
        {
            var userLogin = "Jarosław";
            var userPassword = "Kutas123";
            var response = await _client.GetAsync($"account/Jarosław/Kurr3");
            // response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<LoginUserFoundDTO>(responseString);
            user.Login.Should().BeEquivalentTo(userLogin);
        }
    }
}
