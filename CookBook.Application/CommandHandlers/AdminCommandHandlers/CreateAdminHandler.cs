using CookBook.Application.Commands.AdminCommands;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.CommandHandlers.AdminCommandHandlers
{
    public class CreateAdminHandler : IRequestHandler<CreateAdmin, Admin>
    {
        private readonly IAdminRepository repository;

        public CreateAdminHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<Admin> Handle(CreateAdmin request, CancellationToken cancellationToken)
        {
            var admin = new Admin()
            {
                UserName = request.UserName,
                Password = request.Password
            };

            if (admin == null)
                return null;

            repository.Insert(admin);
            repository.SaveChanges();

            return Task.FromResult(admin);
        }
    }
}
