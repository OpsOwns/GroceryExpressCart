using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;
using System.Collections.Generic;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class PaginationMealQuery : IRequest<Result<IEnumerable<MealsDTO>>>
    {
        public PaginationMealQuery(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
