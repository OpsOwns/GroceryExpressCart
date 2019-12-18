using GroceryExpressCart.Infrastructure.DTO;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Command
{
    public class CreateTokenCommand : IRequest<JwtDTO>
    {
        public string Login { get; set; }
    }
}
