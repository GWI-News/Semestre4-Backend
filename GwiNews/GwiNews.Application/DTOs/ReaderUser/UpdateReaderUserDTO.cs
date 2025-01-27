namespace GwiNews.Application.DTOs.ReaderUser
{
    public class UpdateReaderUserDTO
    {
        public Guid? Id { get; set; }
        public UserRoleDTO? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
    }
}
