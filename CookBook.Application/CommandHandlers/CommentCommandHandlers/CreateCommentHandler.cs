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
    public class CreateCommentHandler : IRequestHandler<CreateComment, Comment>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IPostRepository postRepository;

        public CreateCommentHandler(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            this.commentRepository = commentRepository;
            this.postRepository = postRepository;
        }

        public Task<Comment> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var comment = new Comment()
            {
                PostId = request.PostId,
                Post = postRepository.GetEntityByID(request.PostId),
                Content = request.Content
            };

            if (comment == null)
                return null;

            commentRepository.Insert(comment);
            commentRepository.SaveChanges();

            return Task.FromResult(comment);
        }
    }
}
