using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Events
{
    public class LoginAccountEvent : IDomainEvent
    {
        public DateTime InvokedAt { get; }
        public string Value { get; }
        public LoginAccountEvent(DateTime date, string value)
        {
            InvokedAt = date;
            Value = value;
        }
    }
}
