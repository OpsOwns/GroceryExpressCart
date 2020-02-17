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
    [Route("meal")]
    public class MealController : BaseController
    {
        public MealController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMeal([FromBody] MealDTO mealDTO)
        {
            var command = new CreateMealCommand(mealDTO.Meal, mealDTO.Price, mealDTO.Url);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result.Success);
        }
        [HttpGet]
        [Route("get/{mealId}")]
        public async Task<IActionResult> GetMeal(int mealId)
        {
            var command = new GetMealQuery(mealId);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Ok(result);
        }
        [HttpPut]
        [Route("update/{mealId}")]
        public async Task<IActionResult> UpdateMeal(int mealId, [FromBody] MealDTO mealDTO)
        {
            var command = new UpdateMealCommand(mealId, mealDTO.Meal, mealDTO.Price, mealDTO.Url);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result.Success);
        }
        [HttpDelete]
        [Route("delete/{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var command = new DeleteMealCommand(mealId);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Created(string.Empty, result.Success);
        }
        [HttpGet]
        [Route("getMeals/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetMeals(int pageNumber, int pageSize)
        {
            var command = new PaginationMealQuery(pageNumber, pageSize);
            var result = await _mediatr.Send(command);
            return result.Failure
          ? Conflict(result)
          : (IActionResult)Ok(result);
        }
    }
}
