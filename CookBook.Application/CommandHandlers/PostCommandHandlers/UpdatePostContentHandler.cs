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
    public class UpdatePostContentHandler : IRequestHandler<UpdatePostContent, Post>
    {
        private readonly IPostRepository repository;

        public UpdatePostContentHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<Post> Handle(UpdatePostContent request, CancellationToken cancellationToken)
        {
            var post = repository.GetEntityByID(request.PostId);

            if (post.UserId == request.UserId)
            {
                post.Content = request.NewPostContent;

                repository.Update(post);
                repository.SaveChanges();

                return Task.FromResult(post);
            }
            else
                throw new Exception("You cannot edit other user's posts!");

        }
    }
}
