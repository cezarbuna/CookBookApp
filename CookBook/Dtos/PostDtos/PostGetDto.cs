using CookBook.Domain.Models;

namespace CookBook.Dtos.PostDtos
{
    public class PostGetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int LikeCounter { get; set; } = 0;
        public int DislikeCunter { get; set; } = 0;
        public int Category { get; set; } = 1;
    }
}
