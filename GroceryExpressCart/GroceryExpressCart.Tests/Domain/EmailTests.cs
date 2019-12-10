using FluentAssertions;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Core.ValueObjects;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class EmailTests
    {
        [Fact]
        public void EmailShouldBeThrowExceptionTest()
        {
            var exception = Assert.Throws<GroceryException>(() =>
            Email.Create(string.Empty));
            Assert.Equal(nameof(Parameters.INVALID_EMAIL), exception.Code);
        }

        [Fact]
        public void EmailShouldBeNotNullTest()
        {
            var email = Email.Create("email@o2.pl");
            email.Value.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public void EmailsShouldBeSameTest()
        {
            var email1 = Email.Create("email@o2.pl");
            var email2 = Email.Create("email@o2.pl");
            var expectedValue = email1.GetHashCode().Equals(email2.GetHashCode());
            var expectedValue2 = email1 == email2;
            Assert.True(expectedValue);
            Assert.True(expectedValue2);
        }
    }
}
