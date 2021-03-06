﻿using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObject
{
    public class Email : ValueObject<Email>
    {
        public string EmailValue { get; protected set; }
        public static Email EmailEmpty => new Email(nameof(Parameters.EMPTY));
        protected Email() { }
        private Email(string email) => EmailValue = email;

        public static Result<Email> Create(string email)
        {
            if (email.IsEmpty())
                return Result.FailEmpty(nameof(Parameters.INVALID_EMAIL), EmailEmpty);
            return Result.Ok(new Email(email));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailValue;
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(EmailValue);
    }
}
