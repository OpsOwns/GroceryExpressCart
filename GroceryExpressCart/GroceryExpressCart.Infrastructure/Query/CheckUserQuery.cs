using MediatR;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class CheckUserQuery : IRequest<bool>
    {
        public string Login { get; }
        public string Email { get; }
        public CheckUserQuery(string login, string email)
        {
            Login = login;
            Email = email;
        }
    }
}
