using GroceryExpressCart.Common.Entity;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class DeleteMealCommand : IRequest<Result>
    {
        public int MealId { get; }
        public DeleteMealCommand(int mealId) => MealId = mealId;
    }
}
