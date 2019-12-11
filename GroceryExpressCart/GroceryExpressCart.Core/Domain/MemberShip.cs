using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.ValueObjects;

namespace GroceryExpressCart.Core.Domain
{
    public class MemberShip : AggregateRoot
    {
        public Email Email { get; }
        public Login Login { get; }
        public Password Password { get; set; }
        private MemberShip() { }
        public MemberShip(Email email, Login login, Password password) : this()
        {
            Email = email;
            Login = login;
            Password = password;
        }
        public override int GetHashCode() => HashCodeGenerator.Of(Login).And(Password).And(Email);
    }
}
