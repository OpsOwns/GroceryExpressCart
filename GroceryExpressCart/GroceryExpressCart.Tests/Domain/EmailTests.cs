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
            var exception = Assert.Throws<DomainException>(() =>
            Email.Create(string.Empty));
            Assert.Equal(nameof(Parameters.INVALID_EMAIL), exception.Code);
        }
    }
}
