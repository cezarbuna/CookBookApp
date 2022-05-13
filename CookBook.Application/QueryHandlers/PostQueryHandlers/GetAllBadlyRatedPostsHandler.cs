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
    public class GetAllBadlyRatedPostsHandler : IRequestHandler<GetAllBadlyRatedPosts, List<Post>>
    {
        private readonly IPostRepository repository;

        public GetAllBadlyRatedPostsHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Post>> Handle(GetAllBadlyRatedPosts request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll(x => x.DislikeCunter > x.LikeCounter).ToList());
        }
    }
}
