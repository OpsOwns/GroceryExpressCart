using GroceryExpressCart.Common.Entity;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public int UserId { get; }
        public int MealId { get; }
        public CreateOrderCommand(int userId, int mealId)
        {
            UserId = userId;
            MealId = mealId;
        }
    }
}
