using Autofac;
using System;
using System.Threading.Tasks;

namespace GroceryExpressCart.Common.Entity
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IComponentContext _context;
        public DomainEventDispatcher(IComponentContext context) => _context = context;
        public async Task DispatchAsync<T>(params T[] events) where T : IDomainEvent
        {
            foreach (var @event in events)
            {
                if (@event == null)
                {
                    throw new ArgumentNullException(nameof(@event),
                        $"DomainEvent: '{typeof(T).Name}' can't be null.");
                }
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
                _context.TryResolve(handlerType, out object handler);
                await (Task)((dynamic)handler).HandleAsync(@event);
            }
        }
    }
}
