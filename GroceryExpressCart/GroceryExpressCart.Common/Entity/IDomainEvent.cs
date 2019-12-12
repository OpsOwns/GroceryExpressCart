using System;

namespace GroceryExpressCart.Common.Entity
{
    public interface IDomainEvent
    {
        public DateTime InvokedAt { get; }
        public string Value { get; }
    }
}
