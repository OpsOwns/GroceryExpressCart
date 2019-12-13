using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObject
{
    public class Login : ValueObject<Login>
    {
        public static Login LoginEmpty => new Login(nameof(Parameters.EMPTY));
        public string LoginValue { get; }
        protected Login() { }
        private Login(string value) => LoginValue = value;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LoginValue;
        }
        public static Result<Login> Create(string login)
        {
            if (login.IsEmpty() && !login.Length(3, 12))
                return Result.FailEmpty(nameof(Parameters.INVALID_LOGIN), LoginEmpty);
            return Result.Ok(new Login(login));
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(LoginValue);
    }
}
