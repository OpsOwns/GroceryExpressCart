using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand, Result>
    {
        private readonly GroceryContext _context;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public CreateMealHandler(GroceryContext context, IDomainEventDispatcher domainEventDispatcher)
        {
            _context = context;
            _domainEventDispatcher = domainEventDispatcher;
        }
        public async Task<Result> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var price = Price.Create(request.Price);
            if (price.Failure)
                throw new GroceryException(price.Error);
            var meal = new Meal(request.MealName, price.Value);
            await _context.Meal.AddAsync(meal);
            await _domainEventDispatcher.DispatchAsync(meal.DomainEvents.ToArray());
            return Result.Ok(meal);
        }
    }
}
