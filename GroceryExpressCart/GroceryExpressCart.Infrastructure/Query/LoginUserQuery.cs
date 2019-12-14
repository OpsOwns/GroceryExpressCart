using GroceryExpressCart.Infrastructure.DTO;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class LoginUserQuery : IRequest<LoginUserFoundDTO>
    {
        public string Login { get; }
        public string Password { get; }
        public LoginUserQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
