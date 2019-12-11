using FluentAssertions;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class MemberShipTests
    {
        [Fact]
        public void CreateAccountShouldBeNotNull()
        {
            PasswordHasher passwordHasher = new PasswordHasher(new PasswordSettings { SecretKey = "$2y$12$1YIOnDli2aDPGVSrpCBEt.tjEgcK1tX6.a/6yVp9l4h6Crc9UHeHW" });
            var user = new MemberShip(Email.Create("jhoneDone@o2.pl").Value, Login.Create("Jhony22").Value, Password.Create(passwordHasher.HashPassword("jhony22!")).Value);
            user.Should().NotBeNull();
        }
    }
}
