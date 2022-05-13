namespace CookBook.Dtos.AdminDtos
{
    public class AdminGetDto
    {
        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
