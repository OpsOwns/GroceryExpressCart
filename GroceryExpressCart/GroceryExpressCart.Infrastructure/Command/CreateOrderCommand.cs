using GroceryExpressCart.Common.Entity;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public int UserId { get; }
        public int [] MealsId { get; }
        public CreateOrderCommand(int userId, int [] mealsId)
        {
            UserId = userId;
            MealsId = mealsId;
        }
    }
}
