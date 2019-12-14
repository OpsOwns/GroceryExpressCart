using System.Threading;
using System.Threading.Tasks;
using GroceryExpressCart.Infrastructure.Query;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public interface ICheckUserHandler
    {
        Task<bool> Handle(CheckUserQuery request, CancellationToken cancellationToken);
    }
}