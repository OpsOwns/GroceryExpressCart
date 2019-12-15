using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Events;
using GroceryExpressCart.Infrastructure.Database;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class SystemNotificationAccountHandler : IDomainEventHandler<CreatedAccountEvent>,
                                                    IDomainEventHandler<LoginAccountEvent>
    {
        private readonly GroceryContext _context;
        public SystemNotificationAccountHandler(GroceryContext context) => _context = context;
        public async Task HandleAsync(CreatedAccountEvent value) =>
            await SystemNotify(new SystemNotification(value.Value, value.InvokedAt));
        public async Task HandleAsync(LoginAccountEvent value) =>
            await SystemNotify(new SystemNotification(value.Value, value.InvokedAt));
        private async Task SystemNotify(SystemNotification notify)
        {
            await _context.SystemNotification.AddAsync(notify);
            await _context.SaveChangesAsync();
        }
    }
}
