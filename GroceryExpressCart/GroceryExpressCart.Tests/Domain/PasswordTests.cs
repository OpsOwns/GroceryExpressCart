using FluentAssertions;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.ValueObject;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class PasswordTests
    {
        [Fact]
        public void PasswordShouldBeNotNullTest()
        {
            PasswordHasher passwordHasher = new PasswordHasher(new PasswordSettings { SecretKey = "$2y$12$1YIOnDli2aDPGVSrpCBEt.tjEgcK1tX6.a/6yVp9l4h6Crc9UHeHW" });
            var result = Password.Create("Test43123", passwordHasher);

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFailCreatePasswordTest()
        {
            PasswordHasher passwordHasher = new PasswordHasher(new PasswordSettings { SecretKey = "$2y$12$1YIOnDli2aDPGVSrpCBEt.tjEgcK1tX6.a/6yVp9l4h6Crc9UHeHW" });
            var result = Password.Create("Test", passwordHasher);

            Assert.True(result.Failure);
        }

        [Fact]
        public void ShouldBePasswordHashedTest()
        {
            PasswordHasher passwordHasher = new PasswordHasher(new PasswordSettings { SecretKey =  "$2y$12$1YIOnDli2aDPGVSrpCBEt.tjEgcK1tX6.a/6yVp9l4h6Crc9UHeHW" });
            var result = Password.Create("Marian", passwordHasher);
            Assert.NotNull(result.Value.PasswordValue);
        }
    }
}
