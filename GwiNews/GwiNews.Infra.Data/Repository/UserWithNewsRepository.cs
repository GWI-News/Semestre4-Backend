using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class UserWithNewsRepository : IUserWithNewsRepository
    {
        private readonly AppDbContext _context;
        public UserWithNewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserWithNews>> GetUsersWithNews()
        {
            try
            {
                var usersWithNews = await _context.UsersWithNews.ToListAsync();
                return usersWithNews;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWithNews> GetUserWithNews(Guid id)
        {
            try
            {
                var userWithNews = await _context.UsersWithNews.FindAsync(id);
                return userWithNews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserWithNews>> GetActiveUsersWithNews()
        {
            try
            {
                var usersWithNews = await _context.UsersWithNews.Where(u => u.Status == true).ToListAsync();
                return usersWithNews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWithNews> CreateUserWithNews(UserWithNews userWithNews)
        {
            try
            {
                _context.UsersWithNews.Add(userWithNews);
                await _context.SaveChangesAsync();
                return userWithNews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserWithNews> UpdateUserWithNews(UserWithNews userWithNews)
        {
            try
            {
                _context.Update(userWithNews);
                await _context.SaveChangesAsync();
                return userWithNews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserWithNews>> DeleteUserWithNews(UserWithNews userWithNews)
        {
            try
            {
                userWithNews.Status = false;
                _context.Update(userWithNews);
                await _context.SaveChangesAsync();
                return await _context.UsersWithNews.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
