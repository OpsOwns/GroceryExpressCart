using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.ValueObject;
using System.Threading.Tasks;

namespace GroceryExpressCart.Core.Repository
{
    public interface IMemberShipRepository : IRepository
    {
        Task Add(MemberShip person);
        Task<MemberShip> GetMemberShipById(int mealId);
        Task<MemberShip> GetMemberShipByLoginPassword(string login, string password);
        Task<bool> FindUser(Login login, Email email);
    }
}
