using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CookBook.Application.Commands.UserCommands
{
    public class UpdateUserPhoneNumber : IRequest<User>
    {
        public Guid UserId { get; set; }
        public string NewUserPhoneNumber { get; set; }
    }
}
