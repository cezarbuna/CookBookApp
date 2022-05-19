using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Queries.AdminQueries
{
    public class LoginAdmin : IRequest<Admin>
    {
        public Guid AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
