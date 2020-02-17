using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class PaginationMealHandler : IRequestHandler<PaginationMealQuery, Result<IEnumerable<MealDTO>>>
    {
        private readonly IMealRepository _repository;
        private readonly IMapper _mapper;
        public PaginationMealHandler(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<MealDTO>>> Handle(PaginationMealQuery request, CancellationToken cancellationToken)
        {
            var peginationQuery = new PaginationQuery(request.PageNumber, request.PageSize);
            var result = await _repository.GetMeals(peginationQuery);
            var map = _mapper.Map<IEnumerable<MealDTO>>(result);
            return Result.Ok(map);
        }
    }
}
