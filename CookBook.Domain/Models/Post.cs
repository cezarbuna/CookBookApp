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
    }
}
