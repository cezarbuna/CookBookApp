using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.CommentCommands
{
    public class UpdateCommentContent : IRequest<Comment>
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public string NewContent { get; set; }
    }
}
