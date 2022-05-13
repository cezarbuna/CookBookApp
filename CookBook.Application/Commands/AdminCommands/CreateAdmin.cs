using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Commands.AdminCommands
{
    public class CreateAdmin : IRequest<Admin>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
