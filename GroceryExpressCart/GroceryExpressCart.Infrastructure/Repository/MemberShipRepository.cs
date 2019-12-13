using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Repository
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private GroceryContext _context;
        public MemberShipRepository(GroceryContext context) => _context = context;
        public async Task Add(MemberShip person)
        {
            await _context.MemberShip.AddAsync(person);
            await _context.SaveChangesAsync();
        }
        public async Task<MemberShip> GetMemberShipByLoginPassword(string login, string password) =>
            await _context.MemberShip.SingleOrDefaultAsync(value => value.Login.LoginValue == login && value.Password.PasswordValue == password);
        public async Task<MemberShip> GetMemberShipById(int memberShipId) =>
            await _context.MemberShip.FirstOrDefaultAsync(value => value.Id == memberShipId);
    }
}
