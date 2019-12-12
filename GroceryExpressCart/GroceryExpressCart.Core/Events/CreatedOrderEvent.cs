using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Events
{
    public class CreatedOrderEvent : IDomainEvent
    {
        public DateTime InvokedAt { get; }
        public string Value { get; }

        public CreatedOrderEvent(DateTime date, string value)
        {
            InvokedAt = date;
            Value = value;
        }
    }
}
