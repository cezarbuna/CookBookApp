using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.CommentCommands
{
    public class UpdateComment : IRequest<Comment>
    {
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}
