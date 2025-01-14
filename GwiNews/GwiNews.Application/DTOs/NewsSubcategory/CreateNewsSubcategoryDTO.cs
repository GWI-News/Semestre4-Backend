namespace GwiNews.Application.DTOs.NewsSubcategory
{
    public class CreateNewsSubcategoryDTO
    {
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
