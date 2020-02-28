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
    public class PaginationMealHandler : IRequestHandler<PaginationMealQuery, Result<IEnumerable<MealsDTO>>>
    {
        private readonly IMealRepository _repository;
        private readonly IMapper _mapper;
        public PaginationMealHandler(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<MealsDTO>>> Handle(PaginationMealQuery request, CancellationToken cancellationToken)
        {
            var peginationQuery = new PageParams(request.PageSize, request.PageNumber);
            var result = await _repository.GetMeals(peginationQuery);
            var map = _mapper.Map<IEnumerable<MealsDTO>>(result);
            return Result.Ok(map);
        }
    }
}
