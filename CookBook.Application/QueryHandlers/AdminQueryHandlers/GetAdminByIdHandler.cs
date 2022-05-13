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
    public class GetAdminByIdHandler : IRequestHandler<GetAdminById, Admin>
    {
        private readonly IAdminRepository repository;

        public GetAdminByIdHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<Admin> Handle(GetAdminById request, CancellationToken cancellationToken)
        {
            var admin = repository.GetEntityByID(request.AdminId);

            return Task.FromResult(admin);
        }
    }
}
