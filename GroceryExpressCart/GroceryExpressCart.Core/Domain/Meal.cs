using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Events;
using GroceryExpressCart.Core.ValueObject;
using System;
using System.Collections.Generic;

namespace GroceryExpressCart.Core.Domain
{
    public class Meal : AggregateRoot
    {
        public string MealName { get; private set; }
        public Price Price { get; private set; }
        public ImageDish ImageDish { get; private set; }
        public ICollection<Order> Orders { get; }
        private Meal() { }
        public Meal(string mealName, Price price, ImageDish imageDish)
        {
            MealName = mealName;
            Price = price;
            ImageDish = imageDish;
            AddDomainEvent(new CreateMealEvent(DateTime.Now, nameof(EventMessage.CREATED_MEAL)));
        }
        public override int GetHashCode() => HashCodeGenerator.Of(MealName).And(Price);

        public void SetPrice(Price price)
        {
            Price = price;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetImageDish(ImageDish imageDish)
        {
            ImageDish = imageDish;
        }
        public void SetMealName(string mealName)
        {
            MealName = mealName;
        }
    }
}
