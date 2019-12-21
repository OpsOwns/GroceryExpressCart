using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryExpressCart.Common.Exceptions
{
    public class InvalidCommandProblemDetails : ProblemDetails
    {
        const string VALIDATION_MESSAGE = "Validation Error";
        public InvalidCommandProblemDetails(GroceryValidationException invalidCommandException)
        {
            Title = invalidCommandException.Code;
            Status = StatusCodes.Status400BadRequest;
            Detail = invalidCommandException.Details;
            Type = "GroceryAPI";
        }
        public InvalidCommandProblemDetails(ValidationException invalidCommandException)
        {
            Title = VALIDATION_MESSAGE;
            Status = StatusCodes.Status409Conflict;
            Detail = invalidCommandException.Message;
            Type = "GroceryAPI";
        }
    }
}
