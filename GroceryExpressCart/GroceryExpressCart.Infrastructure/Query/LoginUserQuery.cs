using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class LoginUserQuery : IRequest<Result<LoginUserFoundDTO>>
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
