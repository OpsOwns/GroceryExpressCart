using System.Threading.Tasks;

namespace GroceryExpressCart.Common.Entity
{
    public interface IDomainEventHandler<in T> where T : IDomainEvent
    {
        public Task HandleAsync(T value);
    }
}
