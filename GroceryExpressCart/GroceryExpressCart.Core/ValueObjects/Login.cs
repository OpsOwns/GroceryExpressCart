using System.Collections.Generic;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;

namespace GroceryExpressCart.Core.ValueObjects
{
    public class Login : ValueObject<Login>
    {
        public string Value { get; }
        private Login(string value) => Value = value;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static Login Create(string login)
        {
            if (login.IsEmpty() && !login.Length(3,12))
                throw new DomainException(nameof(Parameters.INVALID_LOGIN));
            return new Login(login);
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(Value);
    }
}
