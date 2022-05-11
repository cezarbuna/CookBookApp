using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class Post : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }

        //public ICollection<Comment> CommentsAsociated { get; set; } = new List<Comment>();
    }
}
