using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Route("order")]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CreateOrderCommand), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateMeal([FromBody] OrderDTO orderDTO)
        {
            var command = new CreateOrderCommand(orderDTO.MemberShipId, orderDTO.MealId);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result.Success);
        }
    }
}
