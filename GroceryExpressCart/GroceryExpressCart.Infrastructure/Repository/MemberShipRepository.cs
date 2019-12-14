using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
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
        public async Task<bool> FindUser(Login login, Email email) =>
            await _context.MemberShip.AnyAsync(user => user.Login.LoginValue == login.LoginValue ||
            user.Email.EmailValue == email.EmailValue);

    }
}
