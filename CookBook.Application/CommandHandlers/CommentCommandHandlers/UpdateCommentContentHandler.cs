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
    public class UpdateCommentContentHandler : IRequestHandler<UpdateCommentContent, Comment>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IPostRepository postRepository;

        public UpdateCommentContentHandler(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            this.commentRepository = commentRepository;
            this.postRepository = postRepository;
        }

        public Task<Comment> Handle(UpdateCommentContent request, CancellationToken cancellationToken)
        {
            var comment = commentRepository.GetEntityByID(request.CommentId);

            var commentParentPost = postRepository.GetEntityByID(comment.PostId);
            var commentParentUserId = commentParentPost.UserId;

            if(commentParentUserId == request.UserId)
            {
                comment.Content = request.NewContent;

                commentRepository.Update(comment);
                commentRepository.SaveChanges();

                return Task.FromResult(comment);
            }
            else
            {
                throw new Exception("You cannot edit other user's comments!");
            }
        }
    }
}
