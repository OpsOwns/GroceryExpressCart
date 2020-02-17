using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Infrastructure.DTO;
using MediatR;
using System.Collections.Generic;

namespace GroceryExpressCart.Infrastructure.Query
{
    public class PaginationMealQuery : IRequest<Result<IEnumerable<MealDTO>>>
    {
        public PaginationMealQuery()
        {
            PageNumber = 1;
            PageSize = 100;
        }
        public PaginationMealQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
