using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class GetMealQuery : IRequest<Result<MealDTO>>
    {
        public int MealId { get; }
        public GetMealQuery(int mealId)
        {
            MealId = mealId;
        }
    }
}
