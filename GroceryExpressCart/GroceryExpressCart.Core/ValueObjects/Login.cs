using System.Collections.Generic;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;

namespace GroceryExpressCart.Core.ValueObjects
{
    public class Login : ValueObject<Login>
    {
        public string LoginValue { get; }
        private Login(string value) => LoginValue = value;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LoginValue;
        }
        public static Result<Login> Create(string login)
        {
            if (login.IsEmpty() && !login.Length(3, 12))
                throw new GroceryException(nameof(Parameters.INVALID_LOGIN));
            return Result.Ok(new Login(login));
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(LoginValue);
    }
}
