using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.PostCommands
{
    public class UpdatePostCategory : IRequest<Post>
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public int NewCategory { get; set; }
    }
}
