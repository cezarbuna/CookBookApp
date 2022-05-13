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
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;

        public CreatePostHandler(IPostRepository postRepository, IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var post = new Post()
            {
                UserId = request.UserId,
                User = userRepository.GetEntityByID(request.UserId),
                Content = request.Content,
                LikeCounter = request.LikeCounter,
                DislikeCunter = request.DislikeCunter
            };

            if (post == null) return null;

            postRepository.Insert(post);
            postRepository.SaveChanges();

            return Task.FromResult(post);
        }
    }
}
