using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsRepository
    {
        public Task<IEnumerable<News>> GetNews();
        public Task<News> GetNewsById(Guid id);
        public Task<IEnumerable<News>> GetPublishedNews();
        public Task<IEnumerable<News>> GetDraftNews();
        public Task<IEnumerable<News>> GetInRevisionNews();
        public Task<News> CreateNews(News news);
        public Task<News> UpdateNews(News news);
        public Task<IEnumerable<News>> DeleteNews(News news);
    }
}
