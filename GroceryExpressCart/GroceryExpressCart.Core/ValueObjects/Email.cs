using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryExpressCart.Core.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string EmailValue { get; }
        private Email(string email) => EmailValue = email;

        public static Result<Email> Create(string email)
        {
            if (email.IsEmpty())
                throw new GroceryException(nameof(Parameters.INVALID_EMAIL));
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
