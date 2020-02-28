using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repository
{
    public interface IMealRepository : IRepository
    {
        Task Add(Meal meal);
        Task<PagedList<Meal>> GetMeals(PageParams paginationQuery = null);
        Task<Meal> GetMealById(int mealId);
        Task Delete(int meailId);
        Task Update(Meal meal);
    }
}
