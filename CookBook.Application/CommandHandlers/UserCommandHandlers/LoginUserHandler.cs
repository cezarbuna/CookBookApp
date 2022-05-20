using CookBook.Application.Commands.UserCommands;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.CommandHandlers.UserCommandHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUser, bool>
    {
        private readonly IUserRepository repository;

        public LoginUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<bool> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var isInRepository = repository.Any(x => x.UserName == request.UserName && x.Password == request.Password);

            return Task.FromResult(isInRepository);
        }
    }
}
