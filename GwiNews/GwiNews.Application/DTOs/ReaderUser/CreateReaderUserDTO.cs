namespace GwiNews.Application.DTOs.ReaderUser
{
    public class CreateReaderUserDTO
    {
        public UserRole? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
    }

    public enum UserRole
    {
        Administrator = 0,
        Editor = 1,
        Author = 2,
        Reader = 3,
        Marketing = 4,
        Financial = 5
    }
}
