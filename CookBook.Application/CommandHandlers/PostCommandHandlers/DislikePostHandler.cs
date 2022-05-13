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
    public class DislikePostHandler : IRequestHandler<DislikePost, Post>
    {
        private readonly IPostRepository repository;

        public DislikePostHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<Post> Handle(DislikePost request, CancellationToken cancellationToken)
        {
            var post = repository.GetEntityByID(request.PostId);

            post.DislikeCunter++;

            repository.Update(post);
            repository.SaveChanges();

            return Task.FromResult(post);
        }
    }
}
