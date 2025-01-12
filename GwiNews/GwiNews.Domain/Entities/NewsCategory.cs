using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class NewsCategory
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }
        [Required]
        public bool? Status { get; set; }
        public ICollection<News>? News { get; set; }
        public ICollection<NewsSubcategory>? Subcategories { get; set; }
    }
}
