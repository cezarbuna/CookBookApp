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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
