using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using Serilog;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IMemberShipRepository _memberShipRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly ILogger _logger;
        public CreateUserHandler(IMemberShipRepository memberShipRepository, IPasswordHasher passwordHasher,
            IDomainEventDispatcher domainEventDispatcher, ILogger logger)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
            _domainEventDispatcher = domainEventDispatcher;
            _logger = logger;
        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Password.Create(request.Password, _passwordHasher);
            var email = Email.Create(request.Email);
            var login = Login.Create(request.Login);
            var result = Result.Combine(email, password, login);
            if (result.Failure)
            {
                _logger.Error(result.Error);
                throw new GroceryException(result.Error);
            }
            if (await IsUserExists(login.Value, email.Value))
                return Result.Fail(nameof(Parameters.USER_EXISTS));
            MemberShip memberShip = new MemberShip(email.Value, login.Value, password.Value);
            await _memberShipRepository.Add(memberShip);
            await _domainEventDispatcher.DispatchAsync(memberShip.DomainEvents.ToArray());
            _logger.Information(nameof(EventMessage.CREATED_USER));
            return Result.Ok(nameof(EventMessage.CREATED_USER));
        }
        private async Task<bool> IsUserExists(Login login, Email email) =>
            await _memberShipRepository.FindUser(login, email);
    }
}
