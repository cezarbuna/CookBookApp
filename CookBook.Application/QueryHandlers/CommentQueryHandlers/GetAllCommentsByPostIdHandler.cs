using CookBook.Application.Queries.CommentQueries;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.QueryHandlers.CommentQueryHandlers
{
    public class GetAllCommentsByPostIdHandler : IRequestHandler<GetAllCommentsByPostId, List<Comment>>
    {
        private readonly ICommentRepository repository;

        public GetAllCommentsByPostIdHandler(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Comment>> Handle(GetAllCommentsByPostId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll(x => x.PostId == request.PostId).ToList());
        }
    }
}
