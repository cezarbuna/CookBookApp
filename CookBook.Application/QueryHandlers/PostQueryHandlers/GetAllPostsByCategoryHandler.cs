using CookBook.Application.Queries.PostQueries;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.PostQueryHandlers
{
    public class GetAllPostsByCategoryHandler : IRequestHandler<GetAllPostsByCategory, List<Post>>
    {
        private readonly IPostRepository repository;

        public GetAllPostsByCategoryHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Post>> Handle(GetAllPostsByCategory request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll(x => x.Category == request.Category).ToList());
        }
    }
}
