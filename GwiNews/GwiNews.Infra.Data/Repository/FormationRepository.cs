using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class FormationRepository : IFormationRepository
    {
        private readonly AppDbContext _context;
        public FormationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Formation>> GetFormations()
        {
            try
            {
                var formations = await _context.Formations.ToListAsync();
                return formations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Formation> GetFormation(Guid id)
        {
            try
            {
                var formation = await _context.Formations.FindAsync(id);
                return formation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Formation>> GetActiveFormations()
        {
            try
            {
                var formations = await _context.Formations.Where(f => f.Status == true).ToListAsync();
                return formations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Formation>> GetFormationsByUserId(Guid userId)
        {
            try
            {
                var formations = await _context.Formations.Where(f => f.UserId == userId).ToListAsync();
                return formations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Formation>> GetActiveFormationsByUserId(Guid userId)
        {
            try
            {
                var formations = await _context.Formations.Where(f => f.Status == true && f.UserId == userId).ToListAsync();
                return formations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Formation> CreateFormation(Formation formation)
        {
            try
            {
                _context.Formations.Add(formation);
                await _context.SaveChangesAsync();
                return formation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Formation> UpdateFormation(Formation formation)
        {
            try
            {
                _context.Update(formation);
                await _context.SaveChangesAsync();
                return formation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Formation>> DeleteFormation(Formation formation)
        {
            try
            {
                formation.Status = false;
                _context.Update(formation);
                await _context.SaveChangesAsync();
                return await _context.Formations.Where(f => f.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
