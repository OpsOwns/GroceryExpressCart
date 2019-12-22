using FluentValidation;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Infrastructure.Command;

namespace GroceryExpressCart.Infrastructure.Validation
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(value => value.Login).NotEmpty().Matches(RegexPatterns.LOGIN_REGEX);
            RuleFor(value => value.Email).NotEmpty().EmailAddress();
            RuleFor(value => value.Password).NotEmpty().Matches(RegexPatterns.PASSWORD_REGEX);
        }
    }
}
