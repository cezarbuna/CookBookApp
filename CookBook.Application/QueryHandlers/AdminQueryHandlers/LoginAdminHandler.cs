using CookBook.Application.Queries.AdminQueries;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.AdminQueryHandlers
{
    public class LoginAdminHandler : IRequestHandler<LoginAdmin, Admin>
    {
        private IAdminRepository repository;

        public LoginAdminHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<Admin> Handle(LoginAdmin request, CancellationToken cancellationToken)
        {
            var admin = repository.GetEntityBy(x => x.UserName == request.UserName && x.Password == request.Password && x.AdminId == request.AdminId);

            if (admin == null)
                return null;

            return Task.FromResult(admin);
        }
    }
}
