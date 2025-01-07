using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Interfaces
{
    public interface IUser
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? CompleteName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(510)]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(1020)]
        public string? Password { get; set; }
        [Required]
        public bool? Status { get; set; }
    }

    public enum UserRole
    {
        Administrador = 0,
        Editor = 1,
        Autor = 2,
        Leitor = 3,
        Marketing = 4,
        Financeiro = 5
    }
}
