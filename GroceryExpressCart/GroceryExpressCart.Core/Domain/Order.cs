using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryExpressCart.Core.Domain
{
    public class Order : AggregateRoot
    {
        public Meal Meal { get; }
        public MemberShip Person { get; }
        public DateTime DateOrder { get; private set; }
        private Order() {}
        public Order(Meal meal, MemberShip person)
        {
            Meal = meal;
            Person = person;
            DateOrder = DateTime.Now;
            AddDomainEvent(new CreatedOrderEvent(DateTime.Now, "Created Meal"));
        }
    }
}
