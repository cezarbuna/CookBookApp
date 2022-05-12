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
    public class UpdateUserUsernameHandler : IRequestHandler<UpdateUserUsername, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserUsernameHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUserUsername request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);

            user.Email = request.NewUserUsername;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
