namespace GwiNews.Application.DTOs.UserWithNews
{
    public class CreateUserWithNewsDTO
    {
        public UserRole? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
    }
}
