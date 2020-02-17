using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class UpdateMealHandler : IRequestHandler<UpdateMealCommand, Result>
    {
        private readonly IMealRepository _repository;
        public UpdateMealHandler(IMealRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var price = Price.Create(request.Price);
            var url = ImageDish.Create(request.Url);
            if (price.Failure || url.Failure)
                throw new GroceryException(price.Error, url.Error);
            var meal = new Meal(request.MealName, price.Value, url.Value);
            meal.SetId(request.MealId);
            await _repository.Update(meal);
            return Result.Ok();
        }
    }
}
