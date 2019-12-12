using FluentAssertions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Core.ValueObjects;
using System.Collections.Generic;
using Xunit;

namespace GroceryExpressCart.Tests.Domain
{
    public class PriceTests
    {
        public static IEnumerable<object[]> AddMoneyValues =>
        new List<object[]>
        {
            new object[] { 1.2M, 2.1M, 3.3M },
            new object[] { 5.0M, 3.5M, 8.5M },
            new object[] { 15.0M, 15.0M, 30.0M },
        };
        public static IEnumerable<object[]> OddMoneyValues =>
        new List<object[]>
        {
            new object[] { 5.2M, 2.1M, 3.1M },
            new object[] { 5.0M, 3.5M, 1.5M },
            new object[] { 15.0M, 15.0M, 0.0M },
        };
        public static IEnumerable<object[]> MultiplyMoneyValues =>
        new List<object[]>
        {
            new object[] { 5.2M, 2, 10,4M },
            new object[] { 5.0M, 3, 15.0M }
           // new object[] { 15.0M, 15, 225.0M },
        };
        [Fact]
        public void PriceShouldBeNotNullTest()
        {
            var price = Price.Create(10.0M);
            price.Should().NotBeNull();
        }
        [Fact]
        public void PriceValueShouldBeNotLessThanZeroTest()
        {
            var price = Price.Create(-10.0M);
            price.Failure.Should().BeTrue();
            price.Error.Should().Be(nameof(Parameters.INVALID_VALUE_MONEY));
        }
        [Theory]
        [MemberData(nameof(AddMoneyValues))]
        public void PriceValueAddTest(decimal value1, decimal value2, decimal expectedResult)
        {
            var priceOne = Price.Create(value1).Value;
            var priceTwo = Price.Create(value2).Value;
            var result = priceOne + priceTwo;
            Assert.Equal(expectedResult, result.Money);
        }
        [Theory]
        [MemberData(nameof(OddMoneyValues))]
        public void PriceValueOddTest(decimal value1, decimal value2, decimal expectedResult)
        {
            var priceOne = Price.Create(value1).Value;
            var priceTwo = Price.Create(value2).Value;
            var result = priceOne - priceTwo;
            Assert.Equal(expectedResult, result.Money);
        }
        [Theory]
        [MemberData(nameof(MultiplyMoneyValues))]
        public void PriceValueMulitPlayTest(decimal value1, int value2, decimal expectedResult)
        {
            var priceOne = Price.Create(value1).Value * value2;
            Assert.Equal(expectedResult, priceOne.Money);
        }
    }
}
