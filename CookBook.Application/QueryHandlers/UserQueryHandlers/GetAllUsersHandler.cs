using CookBook.Application.Queries.UserQueries;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.UserQueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<User>>
    {
        private readonly IUserRepository repository;

        public GetAllUsersHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
