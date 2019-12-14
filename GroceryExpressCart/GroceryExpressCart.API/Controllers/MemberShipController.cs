using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Route("account")]
    public class MemberShipController : BaseController
    {
        public MemberShipController(IMediator mediatr) : base(mediatr) { }
        [HttpPost]
        [Route("user/register")]
        [ProducesResponseType(typeof(CreateUserCommand), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var createUserCommand = new CreateUserCommand(userDTO.Login, userDTO.Password, userDTO.Email);
            return Ok(await _mediatr.Send(createUserCommand));
        }
        [HttpGet]
        [Route("user/{login}/{password}")]
        [ProducesResponseType(typeof(LoginUserFoundDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginUser([FromHeader] LoginUserDTO userDTO)
        {
            var loginUserQuery = new LoginUserQuery(userDTO.Login, userDTO.Password);
            return Ok(await _mediatr.Send(loginUserQuery));
        }
    }
}
