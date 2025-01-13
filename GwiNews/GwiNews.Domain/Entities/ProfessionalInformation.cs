using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class ProfessionalInformation
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? CompleteName { get; set; }
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(510)]
        public string? CompleteAddress { get; set; }
        [Required]
        [StringLength(255)]
        public string? Objective { get; set; }
        [Required]
        [StringLength(510)]
        public string? ImgUrl { get; set; }
        [Required]
        public bool? Status { get; set; }
        [StringLength(255)]
        public string? WorkPlatformUrl { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public ReaderUser? User { get; set; }
    }
}
