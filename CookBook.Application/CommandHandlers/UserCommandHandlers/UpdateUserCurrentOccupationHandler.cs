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
    public class UpdateUserCurrentOccupationHandler : IRequestHandler<UpdateUserCurrentOccupation, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserCurrentOccupationHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUserCurrentOccupation request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);

            user.CurrentOccupation = request.NewUserOccupation;

            repository.Update(user);
            repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}
