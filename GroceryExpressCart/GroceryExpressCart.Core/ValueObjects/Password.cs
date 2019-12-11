﻿using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObjects
{
    public class Password : ValueObject<Password>
    {
        public string PasswordValue { get; }
        public static Password PasswordEmpty => new Password(nameof(Parameters.EMPTY));
        private Password(string value) => PasswordValue = value;
        public static Result<Password> Create(string password)
        {
            if (password.IsEmpty() || !password.Length(8, 120))
                return Result.FailEmpty(nameof(Parameters.INVALID_PASSWORD), PasswordEmpty);
            return Result.Ok(new Password(password));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordValue;
        }
    }
}
