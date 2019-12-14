using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class CreateUserCommand : IRequest
    {
        public string Login { get; }
        public string Password { get; }
        public string Email { get; }
        public CreateUserCommand(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
