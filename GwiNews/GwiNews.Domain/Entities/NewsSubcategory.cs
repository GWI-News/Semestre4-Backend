using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class NewsSubcategory
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(55)]
        public string? Name { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public NewsCategory? Category { get; set; }
        public ICollection<News>? News { get; set; }
    }
}
