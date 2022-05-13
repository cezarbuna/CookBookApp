using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Models
{
    public class Admin : BaseEntity
    {
        public Guid AdminId { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
