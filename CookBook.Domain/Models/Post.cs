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

        public int LikeCounter { get; set; } = 0;
        public int DislikeCunter { get; set; } = 0;

        public int Category { get; set; } = 1;
        
        //Category property has : value 0 for breakfast
        //                        value 1 for lunch (default)
        //                        value 2 for dinner
    }
}
