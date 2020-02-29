using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IOrderRepository _repository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IList<Order> orders;
        public CreateOrderHandler(IOrderRepository repository, IDomainEventDispatcher domainEventDispatcher)
        {
            _repository = repository;
            _domainEventDispatcher = domainEventDispatcher;
            orders = new List<Order>();
        }
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if ((request.MealsId?.Length == 0) || request.UserId == 0)
                return Result.Fail(nameof(Parameters.MISS_PARAMETERS));
            request.MealsId.ToList().ForEach(x =>
            {
                orders.Add(new Order(x, request.UserId));
            });
            await _repository.AddRange(orders);
            await _domainEventDispatcher.DispatchAsync(orders[0].DomainEvents.ToArray());
            return Result.Ok();
        }
    }
}
