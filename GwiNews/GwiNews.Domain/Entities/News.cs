using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class News
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        public NewsStatus? Status { get; set; }
        [Required]
        [StringLength(510)]
        public string? NewsUrl { get; set; }
        [Required]
        [StringLength(75)]
        public string? Title { get; set; }
        [Required]
        [StringLength(255)]
        public string? Subtitle { get; set; }
        [Required]
        [StringLength(65535)]
        public string? NewsBody { get; set; }
        [Required]
        [StringLength(510)]
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime? PublishDate { get; set; }
        [Required]
        public Guid? AuthorId { get; set; }
        [Required]
        public UserWithNews? Author { get; set; }
        [Required]
        public Guid? EditorId { get; set; }
        [Required]
        public UserWithNews? Editor { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public NewsCategory? Category { get; set; }
        public ICollection<NewsSubcategory>? Subcategories { get; set; }
        public ICollection<ReaderUser>? FavoritedBy { get; set; }
    }

    public enum NewsStatus
    {
        Published = 0,
        InRevision = 1,
        Draft = 2,
        Inactive = 3
    }
}
