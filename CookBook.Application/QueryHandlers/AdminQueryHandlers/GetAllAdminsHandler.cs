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
    public class GetAllAdminsHandler : IRequestHandler<GetAllAdmins, List<Admin>>
    {
        private readonly IAdminRepository repository;

        public GetAllAdminsHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Admin>> Handle(GetAllAdmins request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
