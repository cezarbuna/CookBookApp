using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.PostCommands
{
    public class DeletePost : IRequest<Post>
    {
        public Guid PostId { get; set; }
    }
}
