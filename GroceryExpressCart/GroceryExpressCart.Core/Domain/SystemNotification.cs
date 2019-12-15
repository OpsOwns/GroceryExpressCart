using GroceryExpressCart.Common.Entity;
using System;

namespace GroceryExpressCart.Core.Domain
{
    public class SystemNotification : Entity
    {
        public Guid NotificationId { get; }
        public string Message { get; protected set; }
        public DateTime InvokedAt { get; protected set; }
        protected SystemNotification() { }
        public SystemNotification(string message, DateTime invokedAt)
        {
            NotificationId = Guid.NewGuid();
            Message = message;
            InvokedAt= invokedAt;
        }
    }
}
