using FluentAssertions;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.IntegrationTests.BaseSettings;
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
            var request = new UserDTO() { Email = "marianekSzybki@o2.pl", Login = "BossMaluch44", Password = "MaluchFiat95P" };
            var response = await _client.PostAsync($"account/register", GroceryFactory.GetPayload(request));
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be("true");
        }
        [Fact]
        public async Task CreateUserExistsTest()
        {
            var request = new UserDTO() { Email = "lowcybaboli@o2.pl", Login = "GrandZibi12", Password = "ZibiPolska33" };
            var response = await _client.PostAsync($"account/register", GroceryFactory.GetPayload(request));
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().BeEquivalentTo("USER_EXISTS");
        }
        [Fact]
        public async Task LoginUserTest()
        {
            var request = new UserDTO() { Email = "lowcybaboli@o2.pl", Login = "GrandZibi12", Password = "ZibiPolska33" };
            await _client.PostAsync($"account/register", GroceryFactory.GetPayload(request));
            var response = await _client.GetAsync($"account/{request.Login}/{request.Password}");
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<LoginUserFoundDTO>(responseString);
            user.Email.Should().ContainEquivalentOf("lowcybaboli@o2.pl");
        }
        [Fact]
        public async Task LoginFailUserTest()
        {
            var request = new LoginUserDTO() { Login = "GrandZibi12", Password = "ZibiPolska3" };
            var response = await _client.GetAsync($"account/{request.Login}/{request.Password}");
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().BeEquivalentTo("INVALID_USER");
        }
    }
}
