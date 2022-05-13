using CookBook.Domain.Models;

namespace CookBook.Dtos.CommentDtos
{
    public class CommentGetDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public string Content { get; set; }
    }
}
