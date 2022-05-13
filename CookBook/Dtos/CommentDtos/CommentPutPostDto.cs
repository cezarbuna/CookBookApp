using System.ComponentModel.DataAnnotations;

namespace CookBook.Dtos.CommentDtos
{
    public class CommentPutPostDto
    {
        [Required]
        public Guid PostId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
