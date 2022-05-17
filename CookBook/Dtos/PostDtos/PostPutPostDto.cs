using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos.PostDtos
{
    public class PostPutPostDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int LikeCounter { get; set; } = 0;

        [Required]
        public int DislikeCunter { get; set; } = 0;

        [Required]
        public int Category { get; set; } = 1;
    }
}
