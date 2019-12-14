using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroceryExpressCart.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly IMediator _mediatr;
        public BaseController(IMediator mediatr) => _mediatr = mediatr;
    }
}
