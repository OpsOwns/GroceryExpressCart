using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Events
{
    public class CreatedAccountEvent : IDomainEvent
    {
        public DateTime InvokedAt { get; }
        public string Value { get; }
        public CreatedAccountEvent(DateTime date, string value)
        {
            InvokedAt = date;
            Value = value;
        }
    }
}
