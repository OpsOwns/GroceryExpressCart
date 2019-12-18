using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
namespace GroceryExpressCart.Common.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordSettings _settings;
        public PasswordHasher(PasswordSettings settings) =>
            _settings = settings;
        public string HashPassword(string password)
        {
            string hashedPassword = _settings.GenerateSalt ? BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt()):
                                    BCrypt.Net.BCrypt.HashPassword(password, _settings.SecretKey);
            if (hashedPassword.IsEmpty())
                throw new GroceryException(nameof(Parameters.INVALID_HASH_PASSWORD), "Password hash invalid");
            return hashedPassword;
        }
        public bool VerifyHashedPassword(string hashedPassword, string password) =>
             BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
