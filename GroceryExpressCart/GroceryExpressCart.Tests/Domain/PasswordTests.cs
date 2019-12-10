using FluentAssertions;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class PasswordTests
    {
        [Fact]
        public void PasswordShouldBeNotNullTest()
        {
            var result = Password.Create("Test43123");

            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void ShouldFailCreatePasswordTest()
        {
            var result = Password.Create("Test");

            Assert.True(result.Failure);
        }

        [Fact]
        public void ShouldBePasswordHashedTest()
        {
            PasswordHasher passwordHasher = new PasswordHasher(new PasswordSettings { SecretKey = "efswerwer545345!!" });
            var result = Password.Create(passwordHasher.HashPassword("Marian"));
            Assert.NotNull(result.Value.Value);
        }
    }
}
