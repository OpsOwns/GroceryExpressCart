using FluentAssertions;
using GroceryExpressCart.Infrastructure.DTO;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GroceryExpressCart.IntegrationTests
{
    public class UserControllerTests
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;
        public UserControllerTests()
        {
            _server = new GroceryFactory().Server;
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task CreateUserTest()
        {
            var userLogin = "Jarosław";
            var userPassword = "Kutas123";
            var response = await _client.GetAsync($"account/Jarosław/Kurr32");
            // response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<LoginUserFoundDTO>(responseString);
            user.Login.Should().BeEquivalentTo(userLogin);
        }
    }
}
