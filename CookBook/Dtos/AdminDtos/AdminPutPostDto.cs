using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos.AdminDtos
{
    public class AdminPutPostDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
