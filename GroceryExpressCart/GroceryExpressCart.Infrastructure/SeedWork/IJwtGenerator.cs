using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Infrastructure.DTO;

namespace GroceryExpressCart.Infrastructure.SeedWork
{
    public interface IJwtGenerator
    {
        JwtDTO Generate(MemberShip memberShip);
    }
}