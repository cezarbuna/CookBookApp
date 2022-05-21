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
    public class UpdateAdminHandler : IRequestHandler<UpdateAdmin, Admin>
    {
        private readonly IAdminRepository repository;

        public UpdateAdminHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<Admin> Handle(UpdateAdmin request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityBy(x => x.AdminId == request.AdminId);

            //updated.AdminId = request.AdminId;
            updated.UserName = request.UserName;
            updated.Password = request.Password;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
