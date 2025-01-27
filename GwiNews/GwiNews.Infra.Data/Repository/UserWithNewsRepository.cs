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
                var userWithNews = await _context.UsersWithNews
                    .Include(u => u.AuthoredNews)
                    .Include(u => u.EditedNews)
                    .FirstOrDefaultAsync(u => u.Id == id);
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
                var trackedEntity = _context.ChangeTracker.Entries<UserWithNews>()
                    .FirstOrDefault(e => e.Entity.Id == userWithNews.Id);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
                }

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
                return await _context.UsersWithNews.Where(u => u.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
