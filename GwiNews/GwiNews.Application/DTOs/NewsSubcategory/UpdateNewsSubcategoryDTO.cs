namespace GwiNews.Application.DTOs.NewsSubcategory
{
    public class UpdateNewsSubcategoryDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
