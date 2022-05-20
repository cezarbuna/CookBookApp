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
    public class LoginAdminHandler : IRequestHandler<LoginAdmin, bool>
    {
        private readonly IAdminRepository repository;

        public LoginAdminHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<bool> Handle(LoginAdmin request, CancellationToken cancellationToken)
        {
            var isInRepository = repository.Any(x => x.UserName == request.UserName && x.Password == request.Password && x.AdminId == request.AdminId);

            return Task.FromResult(isInRepository);
        }
    }
}
