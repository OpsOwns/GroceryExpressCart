using FluentAssertions;
using GroceryExpressCart.Common.CustomException;
using GroceryExpressCart.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class EmailTests
    {
        [Fact]
        public void EmailShouldBeThrowExceptionTest()
        {
            Assert.Throws<DomainException>(() => Email.Create(string.Empty));
        }
    }
}
