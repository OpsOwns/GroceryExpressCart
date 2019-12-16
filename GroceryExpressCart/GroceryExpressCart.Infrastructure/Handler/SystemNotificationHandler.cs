using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Events;
using GroceryExpressCart.Infrastructure.Database;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class SystemNotificationHandler : IDomainEventHandler<CreatedAccountEvent>,
                                             IDomainEventHandler<LoginAccountEvent>,
                                             IDomainEventHandler<CreateMealEvent>
    {
        private readonly GroceryContext _context;
        public SystemNotificationHandler(GroceryContext context) => _context = context;
        public async Task HandleAsync(CreatedAccountEvent value) =>
            await SystemNotify(new SystemNotification(value.Value, value.InvokedAt));
        public async Task HandleAsync(LoginAccountEvent value) =>
            await SystemNotify(new SystemNotification(value.Value, value.InvokedAt));
        public async Task HandleAsync(CreateMealEvent value) =>
            await SystemNotify(new SystemNotification(value.Value, value.InvokedAt));
        private async Task SystemNotify(SystemNotification notify)
        {
            await _context.SystemNotification.AddAsync(notify);
            await _context.SaveChangesAsync();
        }
    }
}
