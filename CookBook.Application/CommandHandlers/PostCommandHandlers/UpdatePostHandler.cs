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
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository repository;

        public UpdatePostHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var updated = repository.GetEntityByID(request.PostId);

            updated.Id = request.PostId;
            updated.Title = request.Title;
            updated.Content = request.Content;
            updated.Category = request.Category;

            repository.Update(updated);
            repository.SaveChanges();

            return Task.FromResult(updated);
        }
    }
}
