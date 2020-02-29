using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;
using System.Collections.Generic;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class GetMealsQuery : IRequest<Result<IEnumerable<OrderMealDTO>>>
    {
    }
}
