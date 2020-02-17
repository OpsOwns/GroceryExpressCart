using GroceryExpressCart.Common.Entity;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class UpdateMealCommand : IRequest<Result>
    {
        public int MealId { get; }
        public string MealName { get; }
        public decimal Price { get; }
        public string Url { get; }
        public UpdateMealCommand(int mealId, string mealName, decimal price, string url)
        {
            MealId = mealId;
            MealName = mealName;
            Price = price;
            Url = url;
        }

    }
}
