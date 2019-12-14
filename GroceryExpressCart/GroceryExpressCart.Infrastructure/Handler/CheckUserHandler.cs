using System.Threading;
using System.Threading.Tasks;
using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CheckUserHandler : IRequestHandler<CheckUserQuery, bool>, ICheckUserHandler
    {
        IMemberShipRepository _memberShipRepository;
        public CheckUserHandler(IMemberShipRepository memberShipRepository)
        {
            _memberShipRepository = memberShipRepository;
        }
        public async Task<bool> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var login = Login.Create(request.Login);
            var email = Email.Create(request.Email);
            var result = Result.Combine(login, email);
            if (result.Failure)
                throw new GroceryException(result.Error);
            return await _memberShipRepository.FindUser(login.Value, email.Value);
        }
    }
}
