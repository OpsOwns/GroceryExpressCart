using GroceryExpressCart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repositories
{
    public interface IMealRepository
    {
        Task Add(Meal meal);
        Task<IEnumerable<Meal>> GetMeals();
        Task<Meal> GetMealById(int mealId);
    }
}
