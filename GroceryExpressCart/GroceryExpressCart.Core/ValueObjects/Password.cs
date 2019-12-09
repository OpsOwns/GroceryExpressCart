using System.Collections.Generic;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;

namespace GroceryExpressCart.Core.ValueObjects
{
    public class Password : ValueObject<Password>
    {
        public string Value { get; }
        private Password(string value) => Value = value;
        public static Password Create(string password)
        {
            if(password.IsEmpty() && !password.Length(8,16))
                throw new DomainException(nameof(Parameters.INVALID_PASSWORD));
            BCrypt.Net.BCrypt.HashPassword()
            return new Password();
        }
        public string HashPassword(string password)
        {

        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}
