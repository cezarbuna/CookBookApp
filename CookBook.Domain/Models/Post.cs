using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class Post : BaseEntity
    {
        #region Foreign keys
        public Guid UserId { get; set; }
        public User User { get; set; }
        #endregion

        public string Content { get; set; }

        public int Liked { get; set; } = 0;

        //if Liked = 0, the post has not been liked or disliked (default value is 0)
        //if Liked = 1, the post has been liked
        //if Liked = 2, the post has been disliked
    }
}
