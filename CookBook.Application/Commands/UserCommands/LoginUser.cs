using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.UserCommands
{
    public class LoginUser : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
