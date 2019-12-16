using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Events;
using GroceryExpressCart.Core.ValueObject;
using System;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.Domain
{
    public class Meal : AggregateRoot
    {
        public string MealName { get; }
        public Price Price { get; }
        public ICollection<Order> Orders { get; }
        private Meal() { }
        public Meal(string mealName, Price price)
        {
            MealName = mealName;
            Price = price;
            AddDomainEvent(new CreateMealEvent(DateTime.Now, nameof(EventMessage.CREATED_MEAL)));
        }
        public override int GetHashCode() => HashCodeGenerator.Of(MealName).And(Price);
    }
}
