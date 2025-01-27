using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class ReaderUserRepository : IReaderUserRepository
    {
        private readonly AppDbContext _context;
        public ReaderUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReaderUser>> GetReaderUsers()
        {
            try
            {
                var readerUsers = await _context.ReaderUsers.ToListAsync();
                return readerUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReaderUser> GetReaderUser(Guid id)
        {
            try
            {
                var readerUser = await _context.ReaderUsers
                    .Include(u => u.FavoritedNews)
                    .Include(u => u.ProfessionalInformations)
                    .Include(u => u.ProfessionalSkills)
                    .Include(u => u.Formations)
                    .FirstOrDefaultAsync(u => u.Id == id);
                return readerUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReaderUser>> GetActiveReaderUsers()
        {
            try
            {
                var readerUser = await _context.ReaderUsers.Where(u => u.Status == true).ToListAsync();
                return readerUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReaderUser> CreateReaderUser(ReaderUser readerUser)
        {
            try
            {
                _context.ReaderUsers.Add(readerUser);
                await _context.SaveChangesAsync();
                return readerUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReaderUser> UpdateReaderUser(ReaderUser readerUser)
        {
            try
            {
                var trackedEntity = _context.ChangeTracker.Entries<ReaderUser>()
                    .FirstOrDefault(e => e.Entity.Id == readerUser.Id);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
                }

                _context.Update(readerUser);
                await _context.SaveChangesAsync();
                return readerUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReaderUser>> DeleteReaderUser(ReaderUser readerUser)
        {
            try
            {
                readerUser.Status = false;
                _context.Update(readerUser);
                await _context.SaveChangesAsync();
                return await _context.ReaderUsers.Where(u => u.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
