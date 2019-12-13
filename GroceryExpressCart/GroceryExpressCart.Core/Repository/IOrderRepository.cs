using GroceryExpressCart.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repository
{
    public interface IOrderRepository : IRepository
    {
        Task Add(Order order);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int orderId);
    }
}
