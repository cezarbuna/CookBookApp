using CookBook.Application.Commands.PostCommands;
using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.CommandHandlers.PostCommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost, Post>
    {
        private readonly IPostRepository repository;

        public DeletePostHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<Post> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            var post = repository.GetEntityByID(request.PostId);

            if (post == null) return null;

            repository.Delete(post);
            repository.SaveChanges();

            return Task.FromResult(post);
        }
    }
}
