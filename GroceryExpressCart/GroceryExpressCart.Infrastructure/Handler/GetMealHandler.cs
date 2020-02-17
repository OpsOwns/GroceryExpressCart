using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class GetMealHandler : IRequestHandler<GetMealQuery, Result<MealDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _repository;
        public GetMealHandler(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<MealDTO>> Handle(GetMealQuery request, CancellationToken cancellationToken)
        {
            if (request.MealId == 0)
                throw new GroceryException("INVALID_MEALID");
            var meal = await _repository.GetMealById(request.MealId);
            if (meal is null)
                throw new GroceryException("INVALID_MEALID");
            return Result.Ok(_mapper.Map<MealDTO>(meal));
        }
    }
}
