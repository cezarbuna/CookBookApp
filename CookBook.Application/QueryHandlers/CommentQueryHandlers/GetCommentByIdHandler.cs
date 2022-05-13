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
    public class GetCommentByIdHandler : IRequestHandler<GetCommentById, Comment>
    {
        private readonly ICommentRepository repository;

        public GetCommentByIdHandler(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public Task<Comment> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
            var user = repository.GetEntityByID(request.CommentId);

            return Task.FromResult(user);
        }
    }
}
