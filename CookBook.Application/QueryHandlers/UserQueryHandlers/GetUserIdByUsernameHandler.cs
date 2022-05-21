using CookBook.Application.Queries.UserQueries;
using CookBook.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.UserQueryHandlers
{
    public class GetUserIdByUsernameHandler : IRequestHandler<GetUserIdByUsername, Guid>
    {
        private readonly IUserRepository repository;

        public GetUserIdByUsernameHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(GetUserIdByUsername request, CancellationToken cancellationToken)
        {
            var id = repository.GetEntityBy(x => x.UserName == request.UserName).Id;

            if (id == Guid.Empty)
                return Task.FromResult(Guid.Empty);

            return Task.FromResult(id);
        }
    }
}
