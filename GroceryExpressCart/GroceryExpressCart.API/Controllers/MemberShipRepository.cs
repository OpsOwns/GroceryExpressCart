using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Route("memberShip")]
    [ApiController]
    public class MemberShipRepository : Controller
    {
        private readonly IMediator _mediatr;
        public MemberShipRepository(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        [Route("register/user")]
        [ProducesResponseType(typeof(CreateUserCommand), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUser()
        {
            CreateUserCommand createUserCommand = new CreateUserCommand("Janusz", "Kowaslki2", "Januszex43@gmail.com");
            await _mediatr.Send(createUserCommand);
            return Ok();
        }
    }
}
