using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsSubcategoryRepository
    {
        public Task<IEnumerable<NewsSubcategory>> GetNewsSubcategories();
        public Task<NewsSubcategory> GetNewsSubcategory(Guid id);
        public Task<IEnumerable<NewsSubcategory>> GetNewsSubcategoriesByCategoryId(Guid id);
        public Task<IEnumerable<NewsSubcategory>> GetActiveNewsSubcategories();
        public Task<NewsSubcategory> CreateNewsSubcategory(NewsSubcategory newsSubcategory);
        public Task<NewsSubcategory> UpdateNewsSubcategory(NewsSubcategory newsSubcategory);
        public Task<IEnumerable<NewsSubcategory>> DeleteNewsSubcategory(NewsSubcategory newsSubcategory);
    }
}
