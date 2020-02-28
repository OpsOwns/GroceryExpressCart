using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Delete(int mealId)
        {
            _context.Meal.Remove(await _context.Meal.FirstOrDefaultAsync(x => x.Id == mealId));
            await _context.SaveChangesAsync();
        }
        public async Task<Meal> GetMealById(int mealId) =>
            await _context.Meal.FirstOrDefaultAsync(value => value.Id == mealId);
        public async Task<IEnumerable<Meal>> GetMeals() =>
            await _context.Meal.ToListAsync();

        public async Task<PagedList<Meal>> GetMeals(PageParams pageParams)
        {
            return await PagedList<Meal>.CreateAsync(_context.Meal, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task Update(Meal meal)
        {
            var mealToUpdate = await _context.Meal.FirstOrDefaultAsync(x => x.Id == meal.Id);
            if (mealToUpdate != null)
            {
                mealToUpdate.SetImageDish(meal.ImageDish);
                mealToUpdate.SetPrice(meal.Price);
                mealToUpdate.SetMealName(meal.MealName);
                await _context.SaveChangesAsync();
            }
        }
    }
}
