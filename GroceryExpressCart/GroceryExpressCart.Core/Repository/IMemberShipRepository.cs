using GroceryExpressCart.Core.Domain;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repository
{
    public interface IMemberShipRepository : IRepository
    {
        Task Add(MemberShip person);
        Task<MemberShip> GetMemberShipById(int mealId);
        Task<MemberShip> GetMemberShipByLoginPassword(string login, string password);
    }
}
