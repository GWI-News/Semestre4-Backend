namespace GwiNews.Application.DTOs.News
{
    public class UpdateNewsDTO
    {
        public Guid? Id { get; set; }
        public NewsStatus? Status { get; set; }
        public string? NewsUrl { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? NewsBody { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? EditorId { get; set; }
        public Guid? CategoryId { get; set; }
        public ICollection<Guid>? Subcategories { get; set; }
    }
}
