using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class Formation
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        [Required]
        [StringLength(255)]
        public string? Institution { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        [StringLength(255)]
        public string? Activity1 { get; set; }
        [Required]
        [StringLength(255)]
        public string? Activity2 { get; set; }
        [Required]
        [StringLength(255)]
        public string? Activity3 { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public ReaderUser? User { get; set; }
    }
}
