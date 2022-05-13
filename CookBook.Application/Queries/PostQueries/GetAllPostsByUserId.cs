using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Queries.PostQueries
{
    public class GetAllPostsByUserId : IRequest<List<Post>>
    {
        public Guid UserId { get; set; }
    }
}
