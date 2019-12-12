using System.Threading.Tasks;

namespace GroceryExpressCart.Common.Entity
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IDomainEvent;
    }
}