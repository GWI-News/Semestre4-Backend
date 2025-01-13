using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class ProfessionalSkill
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(55)]
        public string? Skill1 { get; set; }
        [Required]
        [StringLength(55)]
        public string? Skill2 { get; set; }
        [Required]
        [StringLength(55)]
        public string? Skill3 { get; set; }
        [Required]
        [StringLength(55)]
        public string? Skill4 { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public ReaderUser? User { get; set; }
    }
}
