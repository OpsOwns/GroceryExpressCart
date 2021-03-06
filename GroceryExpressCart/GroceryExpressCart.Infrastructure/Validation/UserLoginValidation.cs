﻿using FluentValidation;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Infrastructure.Query;

namespace GroceryExpressCart.Infrastructure.Validation
{
    public class UserLoginValidation : AbstractValidator<LoginUserQuery>
    {
        public UserLoginValidation()
        {
            RuleFor(value => value.Login).NotEmpty().Matches(RegexPatterns.LOGIN_REGEX);
            RuleFor(value => value.Password).NotEmpty().Matches(RegexPatterns.PASSWORD_REGEX);
        }
    }
}
