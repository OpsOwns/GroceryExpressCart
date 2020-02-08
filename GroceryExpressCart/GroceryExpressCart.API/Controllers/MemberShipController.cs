using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GroceryExpressCart.API.Controllers
{
    [Route("account")]
    public class MemberShipController : BaseController
    {
        public MemberShipController(IMediator mediatr) : base(mediatr) { }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var createUserCommand = new CreateUserCommand(userDTO.Login, userDTO.Password, userDTO.Email);
            var result = await _mediatr.Send(createUserCommand);
            return result.Failure
                ? Conflict(result.Error)
                : (IActionResult)Created(string.Empty, result.Success);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userDTO)
        {
            var loginUserQuery = new LoginUserQuery(userDTO.Login, userDTO.Password);
            var result = await _mediatr.Send(loginUserQuery);
            return result.Failure ? NotFound(result.Error) : (IActionResult)Ok(result.Value);
        }
    }
}
