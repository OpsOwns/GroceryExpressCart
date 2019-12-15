using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Domain
{
    public class SystemNotification : Entity
    {
        public string Message { get; protected set; }
        public DateTime InvokedAt { get; protected set; }
        protected SystemNotification() { }
        public SystemNotification(string message, DateTime invokedAt)
        {
            Message = message;
            InvokedAt= invokedAt;
        }
    }
}
