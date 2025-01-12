using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class NewsSubcategoryRepository : INewsSubcategoryRepository
    {
        private readonly AppDbContext _context;
        public NewsSubcategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsSubcategory>> GetNewsSubcategories()
        {
            try
            {
                var newsSubcategory = await _context.NewsSubcategories.ToListAsync();
                return newsSubcategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsSubcategory> GetNewsSubcategory(Guid id)
        {
            try
            {
                var newsSubcategory = await _context.NewsSubcategories.FindAsync(id);
                return newsSubcategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsSubcategory>> GetActiveNewsSubcategories()
        {
            try
            {
                var newsSubcategory = await _context.NewsSubcategories.Where(ns => ns.Status == true).ToListAsync();
                return newsSubcategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsSubcategory> CreateNewsSubcategory(NewsSubcategory newsSubcategory)
        {
            try
            {
                _context.NewsSubcategories.Add(newsSubcategory);
                await _context.SaveChangesAsync();
                return newsSubcategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsSubcategory> UpdateNewsSubcategory(NewsSubcategory newsSubcategory)
        {
            try
            {
                _context.Update(newsSubcategory);
                await _context.SaveChangesAsync();
                return newsSubcategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsSubcategory>> DeleteNewsSubcategory(NewsSubcategory newsSubcategory)
        {
            try
            {
                newsSubcategory.Status = false;
                _context.Update(newsSubcategory);
                await _context.SaveChangesAsync();
                return await _context.NewsSubcategories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
