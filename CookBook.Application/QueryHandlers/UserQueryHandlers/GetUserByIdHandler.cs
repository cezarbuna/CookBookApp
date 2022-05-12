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
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUserRepository repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.UserId);
            return Task.FromResult(user);
        }
    }
}
