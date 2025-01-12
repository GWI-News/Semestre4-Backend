using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsCategoryRepository
    {
        public Task<IEnumerable<NewsCategory>> GetNewsCategories();
        public Task<NewsCategory> GetNewsCategory(Guid id);
        public Task<IEnumerable<NewsCategory>> GetActiveNewsCategories();
        public Task<NewsCategory> CreateNewsCategory(NewsCategory newsCategory);
        public Task<NewsCategory> UpdateNewsCategory(NewsCategory newsCategory);
        public Task<IEnumerable<NewsCategory>> DeleteNewsCategory(NewsCategory newsCategory);
    }
}
