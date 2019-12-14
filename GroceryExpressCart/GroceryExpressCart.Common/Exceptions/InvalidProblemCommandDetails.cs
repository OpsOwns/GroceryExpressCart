using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryExpressCart.Common.Exceptions
{
    public class InvalidCommandProblemDetails : ProblemDetails
    {
        public InvalidCommandProblemDetails(GroceryValidationException invalidCommandException)
        {
            Title = invalidCommandException.Code;
            Status = StatusCodes.Status400BadRequest;
            Detail = invalidCommandException.Details;
            Type = "GroceryAPI";
        }
    }
}
