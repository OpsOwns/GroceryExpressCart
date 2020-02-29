using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class GetMealsOrderHandler : IRequestHandler<GetMealsQuery, Result<IEnumerable<OrderMealDTO>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetMealsOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<OrderMealDTO>>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders();
            if (orders is null || orders.Count() == 0)
                return Result.FailEmpty<IEnumerable<OrderMealDTO>>("", null);
            var result = _mapper.Map<IEnumerable<OrderMealDTO>>(orders);
            return Result.Ok(result);
        }
    }
}
