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
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository repository;

        public CreateUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            if (repository.Any(x => x.UserName == request.UserName))
            {
                throw new Exception("UserName is already in use!");
            }

            var user = new User()
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CurrentOccupation = request.CurrentOccupation,
                Description = request.Description
            };

            if (user == null)
                return null;

            repository.Insert(user);
            repository.SaveChanges();

            return Task.FromResult(user);
            
        }
    }
}
