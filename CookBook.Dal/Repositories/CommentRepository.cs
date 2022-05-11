using CookBook.Domain.IRepositories;
using CookBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Dal.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
    }
}
