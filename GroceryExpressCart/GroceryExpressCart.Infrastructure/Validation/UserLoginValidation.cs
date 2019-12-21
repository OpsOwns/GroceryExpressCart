using FluentValidation;
using GroceryExpressCart.Infrastructure.Query;

namespace GroceryExpressCart.Infrastructure.Validation
{
    public class UserLoginValidation : AbstractValidator<LoginUserQuery>
    {
        public UserLoginValidation()
        {
            RuleFor(login => login.Login).NotEmpty().Length(5, 15);
            RuleFor(password => password.Password).NotEmpty().Length(8, 16);
        }
    }
}
