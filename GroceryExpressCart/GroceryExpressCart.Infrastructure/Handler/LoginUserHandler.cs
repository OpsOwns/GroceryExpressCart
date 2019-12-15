using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Events;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, Result<LoginUserFoundDTO>>
    {
        private readonly IMemberShipRepository _memberShipRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        IDomainEventDispatcher _domainEventDispatcher;
        public LoginUserHandler(IMemberShipRepository memberShipRepository,
            IPasswordHasher passwordHasher, IMapper mapper, IDomainEventDispatcher domainEventDispatcher)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _domainEventDispatcher = domainEventDispatcher;
        }
        public async Task<Result<LoginUserFoundDTO>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var login = Login.Create(request.Login);
            var password = Password.Create(_passwordHasher.HashPassword(request.Password));
            var result = Result.Combine(login, password);
            if (result.Failure)
                throw new GroceryException(result.Error);
            var user = await _memberShipRepository.GetMemberShipByLoginPassword(login.Value.LoginValue, password.Value.PasswordValue);
            await _domainEventDispatcher.DispatchAsync(new LoginAccountEvent(DateTime.Now, nameof(EventMessage.LOGIN_USER)));
            return user is null
                ? Result.Fail<LoginUserFoundDTO>(nameof(Parameters.INVALID_USER))
                : Result.Ok(_mapper.Map<LoginUserFoundDTO>(user));
        }
    }
}
