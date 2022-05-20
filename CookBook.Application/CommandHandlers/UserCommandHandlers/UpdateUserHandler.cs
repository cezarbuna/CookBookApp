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
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.UserId);

            updated.Id = request.UserId;
            updated.UserName = request.UserName;
            updated.Password = request.Password;

            updated.Email = request.Email;
            updated.PhoneNumber = request.PhoneNumber;
            updated.CurrentOccupation = request.CurrentOccupation;
            updated.Description = request.Description;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
