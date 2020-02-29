using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private GroceryContext _context;
        public OrderRepository(GroceryContext context) => _context = context;
        public async Task Add(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task AddRange(IEnumerable<Order> order)
        {
            await _context.Order.AddRangeAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<Order> GetOrder(int orderId) =>
            await _context.Order.FirstOrDefaultAsync(value => value.Id == orderId);
        public async Task<IEnumerable<Order>> GetOrders() =>
            await _context.Order.Where(d => d.DateOrder.Date == DateTime.Now.Date).
            Include(x => x.Meal).ToListAsync();
    }
}
