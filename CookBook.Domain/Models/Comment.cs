using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class Comment : BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        //public Guid UserId { get; set; }
        //public User User { get; set; }
        public string Content { get; set; }
    }
}
