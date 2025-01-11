using GwiNews.Domain.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class ReaderUser : IUser
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        public UserRole? Role { get; set; }
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
        public ICollection<News>? FavoritedNews { get; set; }
        public ICollection<ProfessionalInformation>? ProfessionalInformations { get; set; }
        public ICollection<ProfessionalSkill>? ProfessionalSkills { get; set; }
    }
}
