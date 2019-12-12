using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Events
{
    public class CreateMealEvent : IDomainEvent
    {
        public DateTime InvokedAt { get; }
        public string Value { get; }

        public CreateMealEvent(DateTime date, string value)
        {
            InvokedAt = date;
            Value = value;
        }
    }
}
