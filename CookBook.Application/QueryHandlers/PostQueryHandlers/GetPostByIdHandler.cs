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
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository repository;

        public GetPostByIdHandler(IPostRepository repository)
        {
            this.repository = repository;
        }
        public Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            var post = repository.GetEntityByID(request.PostId);

            return Task.FromResult(post);
        }
    }
}
