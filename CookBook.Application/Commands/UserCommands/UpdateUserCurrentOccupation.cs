using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CookBook.Application.Commands.UserCommands
{
    public class UpdateUserCurrentOccupation : IRequest<User>
    {
        public Guid UserId { get; set; }
        public string NewUserOccupation { get; set; }
    }
}
