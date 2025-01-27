using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repository
{
    public class ProfessionalInformationRepository : IProfessionalInformationRepository
    {
        private readonly AppDbContext _context;
        public ProfessionalInformationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfessionalInformation>> GetProfessionalInformations()
        {
            try
            {
                var professionalInformations = await _context.ProfessionalInformations.ToListAsync();
                return professionalInformations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalInformation> GetProfessionalInformation(Guid id)
        {
            try
            {
                var professionalInformation = await _context.ProfessionalInformations.FindAsync(id);
                return professionalInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>> GetActiveProfessionalInformations()
        {
            try
            {
                var professionalInformations = await _context.ProfessionalInformations.Where(pi => pi.Status == true).ToListAsync();
                return professionalInformations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>> GetProfessionalInformationsByUserId(Guid userId)
        {
            try
            {
                var professionalInformations = await _context.ProfessionalInformations.Where(pi => pi.UserId == userId).ToListAsync();
                return professionalInformations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>> GetActiveProfessionalInformationsByUserId(Guid userId)
        {
            try
            {
                var professionalInformations = await _context.ProfessionalInformations.Where(pi => pi.Status == true && pi.UserId == userId).ToListAsync();
                return professionalInformations;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalInformation> CreateProfessionalInformation(ProfessionalInformation professionalInformation)
        {
            try
            {
                _context.ProfessionalInformations.Add(professionalInformation);
                await _context.SaveChangesAsync();
                return professionalInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfessionalInformation> UpdateProfessionalInformation(ProfessionalInformation professionalInformation)
        {
            try
            {
                var trackedEntity = _context.ChangeTracker.Entries<ProfessionalInformation>()
                    .FirstOrDefault(e => e.Entity.Id == professionalInformation.Id);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
                }

                _context.Update(professionalInformation);
                await _context.SaveChangesAsync();
                return professionalInformation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>> DeleteProfessionalInformation(ProfessionalInformation professionalInformation)
        {
            try
            {
                professionalInformation.Status = false;
                _context.Update(professionalInformation);
                await _context.SaveChangesAsync();
                return await _context.ProfessionalInformations.Where(pi => pi.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
