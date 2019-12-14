using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.DTO;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, LoginUserFoundDTO>
    {
        private readonly IMemberShipRepository _memberShipRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        public LoginUserHandler(IMemberShipRepository memberShipRepository, 
            IPasswordHasher passwordHasher, IMapper mapper)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<LoginUserFoundDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var login = Login.Create(request.Login);
            var password = Password.Create(_passwordHasher.HashPassword(request.Password));
            var result = Result.Combine(login, password);
            if (result.Failure)
                throw new GroceryException(result.Error);
            var user = await _memberShipRepository.GetMemberShipByLoginPassword(login.Value.LoginValue, password.Value.PasswordValue);
            if (user is null)
                throw new GroceryException(nameof(Parameters.INVALID_USER));
            return _mapper.Map<LoginUserFoundDTO>(user);
        }
    }
}
