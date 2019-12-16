using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IOrderRepository _repository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public CreateOrderHandler(IOrderRepository repository, IDomainEventDispatcher domainEventDispatcher)
        {
            _repository = repository;
            _domainEventDispatcher = domainEventDispatcher;
        }
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.MealId, request.UserId);
            if (order.MealId == 0 || order.MemberShipId == 0)
                return Result.Fail(nameof(Parameters.MISS_PARAMETERS));
            await _repository.Add(order);
            await _domainEventDispatcher.DispatchAsync(order.DomainEvents.ToArray());
            return Result.Ok(order);
        }
    }
}
