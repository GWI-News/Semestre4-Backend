using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class ProfessionalSkillRepository : IProfessionalSkillRepository
    {
        private readonly AppDbContext _context;
        public ProfessionalSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetProfessionalSkills()
        {
            try
            {
                var professionalSkills = await _context.ProfessionalSkills.ToListAsync();
                return professionalSkills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalSkill> GetProfessionalSkill(Guid id)
        {
            try
            {
                var professionalSkill = await _context.ProfessionalSkills.FindAsync(id);
                return professionalSkill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetActiveProfessionalSkills()
        {
            try
            {
                var professionalSkills = await _context.ProfessionalSkills.Where(ps => ps.Status == true).ToListAsync();
                return professionalSkills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetProfessionalSkillsByUserId(Guid userId)
        {
            try
            {
                var professionalSkills = await _context.ProfessionalSkills.Where(ps => ps.UserId == userId).ToListAsync();
                return professionalSkills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetActiveProfessionalSkillsByUserId(Guid userId)
        {
            try
            {
                var professionalSkills = await _context.ProfessionalSkills.Where(ps => ps.Status == true && ps.UserId == userId).ToListAsync();
                return professionalSkills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalSkill> CreateProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            try
            {
                _context.ProfessionalSkills.Add(professionalSkill);
                await _context.SaveChangesAsync();
                return professionalSkill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalSkill> UpdateProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            try
            {
                var trackedEntity = _context.ChangeTracker.Entries<ProfessionalSkill>()
                    .FirstOrDefault(e => e.Entity.Id == professionalSkill.Id);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
                }

                _context.Update(professionalSkill);
                await _context.SaveChangesAsync();
                return professionalSkill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalSkill>> DeleteProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            try
            {
                professionalSkill.Status = false;
                _context.Update(professionalSkill);
                await _context.SaveChangesAsync();
                return await _context.ProfessionalSkills.Where(ps => ps.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
