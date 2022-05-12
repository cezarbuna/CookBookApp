using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos.UserDtos
{
    public class UserPutPostDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        public string CurrentOccupation { get; set; }

        [MinLength(10)]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
