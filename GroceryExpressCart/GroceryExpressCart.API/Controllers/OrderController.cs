using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("order")]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
        {
            var command = new CreateOrderCommand(orderDTO.MemberShipId, orderDTO.MealsId);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result.Success);
        }
        [HttpGet]
        [Route("today")]
        public async Task<IActionResult> GetMealsToday()
        {
            var command = new GetMealsQuery();
            var result = await _mediatr.Send(command);
            return result.Failure
            ? Conflict(result)
            : (IActionResult)Ok(result);
        }
    }
}
