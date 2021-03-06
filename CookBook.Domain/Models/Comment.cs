using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class Comment : BaseEntity
    {
        #region Foreign keys
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        #endregion

        public string Content { get; set; }
    }
}
