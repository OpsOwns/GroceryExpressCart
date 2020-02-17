using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class DeleteMealHandler : IRequestHandler<DeleteMealCommand, Result>
    {
        private readonly IMealRepository _repository;
        public DeleteMealHandler(IMealRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            if(request.MealId == 0)
                throw new GroceryException("INVALID_MEALID");
            await _repository.Delete(request.MealId);
            return Result.Ok();
        }
    }
}
