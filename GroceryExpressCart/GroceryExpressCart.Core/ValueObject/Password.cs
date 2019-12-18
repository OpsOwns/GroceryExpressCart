using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObject
{
    public class Password : ValueObject<Password>
    {
        public string PasswordValue { get; protected set; }
        public static Password PasswordEmpty => new Password(nameof(Parameters.EMPTY));
        private Password(string value) => PasswordValue = value;
        protected Password() { }
        public static Result<Password> Create(string password, IPasswordHasher passwordHasher)
        {
            if (password.IsEmpty() || !password.Length(8, 120))
                return Result.FailEmpty(nameof(Parameters.INVALID_PASSWORD), PasswordEmpty);
            return Result.Ok(new Password(passwordHasher.HashPassword(password)));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordValue;
        }
        public override int GetHashCode() => HashCodeGenerator.Of(PasswordValue);
    }
}
