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
    public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPassword, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserPasswordHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public Task<User> Handle(UpdateUserPassword request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);

            user.Password = request.NewUserPassword;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
