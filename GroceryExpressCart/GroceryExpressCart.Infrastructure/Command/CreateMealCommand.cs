﻿using GroceryExpressCart.Common.Entity;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class CreateMealCommand : IRequest<Result>
    {
        public string MealName { get; }
        public decimal Price { get; }
        public string  Url { get; }
        public CreateMealCommand(string mealName, decimal price, string url)
        {
            Price = price;
            MealName = mealName;
            Url = url;
        }
    }
}
