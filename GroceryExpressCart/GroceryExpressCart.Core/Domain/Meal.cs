using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.ValueObjects;

namespace GroceryExpressCart.Core.Domain
{
    public class Meal : Entity
    {
        public string MealName { get; }
        public Price Price { get; }
        private Meal() { }
        public Meal(string mealName, Price price)
        {
            MealName = mealName;
            Price = price;
        }
        public override int GetHashCode() => HashCodeGenerator.Of(MealName).And(Price);
    }
}
