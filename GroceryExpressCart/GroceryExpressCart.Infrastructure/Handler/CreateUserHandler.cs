using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result>
    {
        IMemberShipRepository _memberShipRepository;
        IPasswordHasher _passwordHasher;
        public CreateUserHandler(IMemberShipRepository memberShipRepository, IPasswordHasher passwordHasher)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Password.Create(_passwordHasher.HashPassword(request.Password));
            var email = Email.Create(request.Email);
            var login = Login.Create(request.Login);
            var result = Result.Combine(email, password, login);
            if (result.Failure)
                throw new GroceryException(result.Error);
            if (await IsUserExists(login.Value, email.Value))
                return Result.Fail(nameof(Parameters.USER_EXISTS));
            MemberShip memberShip = new MemberShip(email.Value, login.Value, password.Value);
            await _memberShipRepository.Add(memberShip);
            return Result.Ok(nameof(Parameters.CREATED_USER));
        }


        private async Task<bool> IsUserExists(Login login, Email email) =>
            await _memberShipRepository.FindUser(login, email);
    }
}
