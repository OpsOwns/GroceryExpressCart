﻿using GroceryExpressCart.Common.Entity;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Core.Domain;
using GroceryExpressCart.Core.Repository;
using GroceryExpressCart.Core.ValueObject;
using GroceryExpressCart.Infrastructure.Command;
using GroceryExpressCart.Infrastructure.Query;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryExpressCart.Infrastructure.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        IMemberShipRepository _memberShipRepository;
        IPasswordHasher _passwordHasher;
        ICheckUserHandler _checkUserHandler;
        public CreateUserHandler(IMemberShipRepository memberShipRepository, IPasswordHasher passwordHasher, ICheckUserHandler checkUserHandler)
        {
            _memberShipRepository = memberShipRepository;
            _passwordHasher = passwordHasher;
            _checkUserHandler = checkUserHandler;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.Email);
            var password = Password.Create(_passwordHasher.HashPassword(request.Password));
            var login = Login.Create(request.Login);
            var result = Result.Combine(email, password, login);
            if (result.Failure)
                throw new GroceryException(result.Error);
            if (await _checkUserHandler.Handle(new CheckUserQuery(login.Value.LoginValue, email.Value.EmailValue), CancellationToken.None))
                throw new GroceryException(nameof(Parameters.USER_EXISTS));
            MemberShip memberShip = new MemberShip(email.Value, login.Value, password.Value);
            await _memberShipRepository.Add(memberShip);
            return Unit.Value;
        }
    }
}
