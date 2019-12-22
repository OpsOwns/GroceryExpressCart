using FluentValidation;
using MediatR;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.SeedWork
{
    public class ValidatonBehaviour<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse> where Trequest : IRequest<Tresponse>
    {
        private readonly IEnumerable<IValidator<Trequest>> _validators;
        private readonly ILogger _logger;
        public ValidatonBehaviour(IEnumerable<IValidator<Trequest>> validators, ILogger logger)
        {
            _logger = logger;
            _validators = validators;
        }
        public async Task<Tresponse> Handle(Trequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators.Select(fail => fail.Validate(context)).
                SelectMany(errors => errors.Errors).Where(notNull => notNull != null).ToList();
            if (failures.Count > 0)
            {
                failures.ForEach(errors => _logger.Error(errors.ErrorMessage));
                throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
