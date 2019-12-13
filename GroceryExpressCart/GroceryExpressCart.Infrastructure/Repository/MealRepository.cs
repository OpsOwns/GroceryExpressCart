using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Repository
{
    public class MealRepository : IMealRepository
    {
        private GroceryContext _context;
        public MealRepository(GroceryContext context) => _context = context;
        public async Task Add(Meal meal)
        {
            await _context.Meal.AddAsync(meal);
            await _context.SaveChangesAsync();
        }
        public async Task<Meal> GetMealById(int mealId) =>
            await _context.Meal.FirstOrDefaultAsync(value => value.Id == mealId);
        public async Task<IEnumerable<Meal>> GetMeals() =>
            await _context.Meal.ToListAsync();
    }
}
