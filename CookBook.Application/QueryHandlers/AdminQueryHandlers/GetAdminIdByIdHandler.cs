using CookBook.Application.Queries.AdminQueries;
using CookBook.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.AdminQueryHandlers
{
    public class GetAdminIdByIdHandler : IRequestHandler<GetAdminIdById, Guid>
    {
        private readonly IAdminRepository repository;

        public GetAdminIdByIdHandler(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(GetAdminIdById request, CancellationToken cancellationToken)
        {
            var id = repository.GetEntityBy(x => x.Id == request.NormalId).AdminId;

            if (id == Guid.Empty)
                return Task.FromResult(Guid.Empty);

            return Task.FromResult(id);
        }
    }
}
