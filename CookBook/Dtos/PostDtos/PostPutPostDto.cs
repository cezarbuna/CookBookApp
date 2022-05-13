using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos.PostDtos
{
    public class PostPutPostDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int Liked { get; set; } 
    }
}
