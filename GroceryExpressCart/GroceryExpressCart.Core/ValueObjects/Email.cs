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
        public string Value { get; }
        private Email(string email) => Value = email;

        public static Email Create(string email)
        {
            if (email.IsEmpty())
                throw new GroceryException(nameof(Parameters.INVALID_EMAIL));
            return new Email(email);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(Value);
    }
}
