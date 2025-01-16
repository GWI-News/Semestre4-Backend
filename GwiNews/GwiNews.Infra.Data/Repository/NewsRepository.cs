using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _context;
        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            try
            {
                var news = await _context.News.ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> GetNewsById(Guid id)
        {
            try
            {
                var news = await _context.News.FindAsync(id);
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetFavoritedNewsByUserId(Guid userId)
        {
            try
            {
                var news = await _context.News.Where(n => n.FavoritedBy.Any(u => u.Id == userId)).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<News>> GetPublishedNews()
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.Published).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetPublishedNewsByAuthorId(Guid authorId)
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.Published && n.AuthorId == authorId).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetPublishedNewsByEditorId(Guid editorId)
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.Published && n.EditorId == editorId).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetDraftNews()
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.Draft).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetDraftNewsByAuthorId(Guid authorId)
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.Draft && n.AuthorId == authorId).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetInRevisionNews()
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.InRevision).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> GetInRevisionNewsByEditorId(Guid editorId)
        {
            try
            {
                var news = await _context.News.Where(n => n.Status == NewsStatus.InRevision && n.EditorId == editorId).ToListAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> CreateNews(News news)
        {
            try
            {
                _context.News.Add(news);
                await _context.SaveChangesAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> UpdateNews(News news)
        {
            try
            {
                _context.Update(news);
                await _context.SaveChangesAsync();
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<News>> DeleteNews(News news)
        {
            try
            {
                news.Status = NewsStatus.Inactive;
                _context.Update(news);
                await _context.SaveChangesAsync();
                return await _context.News.Where(n => n.Status != NewsStatus.Inactive).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
