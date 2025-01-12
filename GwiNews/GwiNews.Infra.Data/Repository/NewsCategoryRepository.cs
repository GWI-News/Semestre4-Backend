using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        private readonly AppDbContext _context;
        public NewsCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsCategory>> GetNewsCategories()
        {
            try
            {
                var newsCategory = await _context.NewsCategories.ToListAsync();
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsCategory> GetNewsCategory(Guid id)
        {
            try
            {
                var newsCategory = await _context.NewsCategories.FindAsync(id);
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsCategory>> GetActiveNewsCategories()
        {
            try
            {
                var newsCategory = await _context.NewsCategories.Where(nc => nc.Status == true).ToListAsync();
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsCategory> CreateNewsCategory(NewsCategory newsCategory)
        {
            try
            {
                _context.NewsCategories.Add(newsCategory);
                await _context.SaveChangesAsync();
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsCategory> UpdateNewsCategory(NewsCategory newsCategory)
        {
            try
            {
                _context.Update(newsCategory);
                await _context.SaveChangesAsync();
                return newsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsCategory>> DeleteNewsCategory(NewsCategory newsCategory)
        {
            try
            {
                newsCategory.Status = false;
                _context.Update(newsCategory);
                await _context.SaveChangesAsync();
                return await _context.NewsCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
