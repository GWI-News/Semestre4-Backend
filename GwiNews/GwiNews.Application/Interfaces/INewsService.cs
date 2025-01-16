using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;
using GwiNews.Application.DTOs.News;

namespace GwiNews.Application.Interfaces
{
    public interface INewsService
    {
        public Task<ResponseModelDTO<IEnumerable<News>>> GetNews();
        public Task<ResponseModelDTO<News>> GetNewsById(Guid id);
        public Task<ResponseModelDTO<IEnumerable<News>>> GetFavoritedNewsByUserId(Guid id);
        public Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNews();
        public Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNewsByAuthorId(Guid id);
        public Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNewsByEditorId(Guid id);
        public Task<ResponseModelDTO<IEnumerable<News>>> GetDraftNews();
        public Task<ResponseModelDTO<IEnumerable<News>>> GetDraftNewsByAuthorId(Guid id);
        public Task<ResponseModelDTO<IEnumerable<News>>> GetInRevisionNews();
        public Task<ResponseModelDTO<IEnumerable<News>>> GetInRevisionNewsByEditorId(Guid id);
        public Task<ResponseModelDTO<News>> CreateNews(CreateNewsDTO createNewsDTO);
        public Task<ResponseModelDTO<News>> UpdateNews(UpdateNewsDTO updateNewsDTO);
        public Task<ResponseModelDTO<IEnumerable<News>>> DeleteNews(UpdateNewsDTO updateNewsDTO);
    }
}
