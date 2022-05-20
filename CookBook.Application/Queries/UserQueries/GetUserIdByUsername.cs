using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Queries.UserQueries
{
    public class GetUserIdByUsername : IRequest<Guid>
    {
        public string UserName { get; set; }
    }
}
