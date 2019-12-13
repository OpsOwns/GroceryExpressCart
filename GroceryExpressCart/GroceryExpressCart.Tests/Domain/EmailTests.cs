using FluentAssertions;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Core.ValueObject;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class EmailTests
    {
        [Fact]
        public void EmailShouldBeFailTest()
        {
            var email = Email.Create(string.Empty);
            email.Failure.Should().Be(true);
            email.Error.Should().Be(nameof(Parameters.INVALID_EMAIL));
        }

        [Fact]
        public void EmailShouldBeNotNullTest()
        {
            var email = Email.Create("email@o2.pl");
            email.Value.EmailValue.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public void EmailsShouldBeSameTest()
        {
            var email1 = Email.Create("email@o2.pl");
            var email2 = Email.Create("email@o2.pl");
            var expectedValue = email1.Value.GetHashCode().Equals(email2.Value.GetHashCode());
            var expectedValue2 = email1.Value == email2.Value;
            Assert.True(expectedValue);
            Assert.True(expectedValue2);
        }
    }
}
