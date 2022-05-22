using CookBook.Application.Commands.CommentCommands;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.CommandHandlers.CommentCommandHandlers
{
    public class UpdateCommentHandler : IRequestHandler<UpdateComment, Comment>
    {
        private readonly ICommentRepository repository;

        public UpdateCommentHandler(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public Task<Comment> Handle(UpdateComment request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.CommentId);

            updated.Id = request.CommentId;
            updated.PostId = request.PostId;
            updated.Content = request.Content;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
