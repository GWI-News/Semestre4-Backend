namespace GwiNews.Application.DTOs.NewsCategory
{
    public class UpdateNewsCategoryDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
    }
}
