using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Core.Events;
using System;

namespace GroceryExpressCart.Core.Domain
{
    public class Order : AggregateRoot
    {
        public Meal Meal { get; }
        public MemberShip MemberShip { get; }
        public DateTime DateOrder { get; private set; }
        public int MealId { get; }
        public int MemberShipId { get; }
        private Order() { }
        public Order(Meal meal, MemberShip memberShip)
        {
            Meal = meal;
            MemberShip = memberShip;
            MealId = meal.Id;
            MemberShipId = memberShip.Id;
            DateOrder = DateTime.Now;
            AddDomainEvent(new CreatedOrderEvent(DateTime.Now, nameof(EventMessage.CREATED_ORDER)));
        }
        public Order(int mealId, int memberShipId)
        {
            MealId = mealId;
            MemberShipId = memberShipId;
            DateOrder = DateTime.Now;
            AddDomainEvent(new CreatedOrderEvent(DateTime.Now, nameof(EventMessage.CREATED_ORDER)));
        }
        public override int GetHashCode() =>
            HashCodeGenerator.Of(MemberShip).And(DateOrder).And(MemberShip);

    }
}
