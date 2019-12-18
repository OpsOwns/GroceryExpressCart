using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using GroceryExpressCart.Infrastructure.SeedWork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, Result<LoginUserFoundDTO>>
    {
        private readonly IMemberShipRepository _memberShipRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IJwtGenerator _jwtGenerator;
        public LoginUserHandler(IMemberShipRepository memberShipRepository, IJwtGenerator jwtGenerator,
            IPasswordHasher passwordHasher, IMapper mapper, IDomainEventDispatcher domainEventDispatcher)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _domainEventDispatcher = domainEventDispatcher;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<Result<LoginUserFoundDTO>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var login = Login.Create(request.Login);
            var password = Password.Create(request.Password,_passwordHasher);
            var result = Result.Combine(login, password);
            if (result.Failure)
                throw new GroceryException(result.Error);
            var memberShip = new MemberShip(login.Value, password.Value);
            var user = await _memberShipRepository.GetMemberShipByLoginPassword(memberShip.Login.LoginValue, memberShip.Password.PasswordValue);
            await _domainEventDispatcher.DispatchAsync(memberShip.DomainEvents.ToArray());
            var loggedUser = _mapper.Map<LoginUserFoundDTO>(user);
            loggedUser.JwtDTO = _jwtGenerator.Generate(user);
            return user is null
                ? Result.Fail<LoginUserFoundDTO>(nameof(Parameters.INVALID_USER))
                : Result.Ok(loggedUser);
        }
    }
}
