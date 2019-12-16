using MediatR;

namespace GroceryExpressCart.API.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }
    }
}
