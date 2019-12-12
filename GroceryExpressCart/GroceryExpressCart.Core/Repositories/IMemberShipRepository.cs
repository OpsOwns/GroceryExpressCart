using GroceryExpressCart.Core.Domain;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repositories
{
    interface IMemberShipRepository
    {
        Task Add(MemberShip person);
        Task<MemberShip> GetMealById(int mealId);
    }
}
