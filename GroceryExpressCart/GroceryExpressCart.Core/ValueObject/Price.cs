using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using System;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.ValueObject
{
    public class Price : ValueObject<Price>
    {
        public decimal Money { get; protected set; }
        protected Price(){}
        private Price(decimal money) => Money = money;
        public static Result<Price> Create(decimal money)
        {
            if (money < 0)
                return Result.Fail<Price>(nameof(Parameters.INVALID_VALUE_MONEY));
            return Result.Ok(new Price(money));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Money;
        }
        public static Price operator *(Price value1, int count) =>
             new Price(Math.Round(value1.Money * count * 100) / 100);
        public static Price operator -(Price value1, Price value2) => new Price(value1.Money - value2.Money);
        public static Price operator +(Price value1, Price value2) => new Price(value1.Money + value2.Money);
        public override int GetHashCode() => HashCodeGenerator.Of(Money);
        public override string ToString() =>
            Money < 1 ? $"{(Money * 100).ToString("0")} zl" :
            $"{Money.ToString("0.00")} zl";
    }
}
