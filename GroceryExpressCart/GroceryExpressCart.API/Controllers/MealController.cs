using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Route("meal")]
    public class MealController : BaseController
    {
        public MealController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CreateMealCommand), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateMeal([FromBody] MealDTO mealDTO)
        {
            var command = new CreateMealCommand(mealDTO.Meal, mealDTO.Price);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result);
        }
    }
}
