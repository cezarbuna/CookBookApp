using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.PostCommands
{
    public class CreatePost : IRequest<Post>
    {
        public Guid UserId { get; set; }

        public string Content { get; set; }

        public int LikeCounter { get; set; } = 0;
        public int DislikeCunter { get; set; } = 0;
    }
}
