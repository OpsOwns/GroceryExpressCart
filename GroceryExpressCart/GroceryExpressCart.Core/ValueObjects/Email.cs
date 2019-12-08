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
            {//TODO
            }
            return new Email(email);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            return HashCodeGenerator.Of(Value);
        }
    }
}
