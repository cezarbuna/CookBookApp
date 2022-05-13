using CookBook.Domain.Models;

namespace CookBook.Dtos.PostDtos
{
    public class PostGetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }

        public int Liked { get; set; }
    }
}
