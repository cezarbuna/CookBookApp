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
    public class UpdatePostCategoryHandler : IRequestHandler<UpdatePostCategory, Post>
    {
        private readonly IPostRepository repository;

        public UpdatePostCategoryHandler(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Task<Post> Handle(UpdatePostCategory request, CancellationToken cancellationToken)
        {
            var post = repository.GetEntityByID(request.PostId);

            if(post.UserId == request.UserId)
            {
                post.Category = request.NewCategory;

                repository.Update(post);
                repository.SaveChanges();

                return Task.FromResult(post);
            }
            else
            {
                throw new Exception("You cannot edit other user's posts!");
            }          
        }
    }
}
