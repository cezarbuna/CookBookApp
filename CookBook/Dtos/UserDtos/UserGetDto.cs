namespace CookBook.Dtos.UserDtos
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentOccupation { get; set; }
        public string Description { get; set; }
    }
}
