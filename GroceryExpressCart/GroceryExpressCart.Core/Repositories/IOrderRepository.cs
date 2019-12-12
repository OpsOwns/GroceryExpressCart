using GroceryExpressCart.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int orderId);
    }
}
