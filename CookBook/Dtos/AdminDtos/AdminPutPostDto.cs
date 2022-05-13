namespace CookBook.Dtos.AdminDtos
{
    public class AdminPutPostDto
    {
        public Guid AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
