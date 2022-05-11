using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Occupation { get; set; }
        public string PersonalDescription { get; set; }

        //public ICollection<Post> PostsCreated { get; set; } = new List<Post>();
        //public ICollection<Comment> CommentsCreated { get; set; } = new List<Comment>();
    }
}
