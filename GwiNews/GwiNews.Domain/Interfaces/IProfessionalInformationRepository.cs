using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalInformationRepository
    {
        public Task<IEnumerable<ProfessionalInformation>> GetProfessionalInformations();
        public Task<ProfessionalInformation> GetProfessionalInformation(Guid id);
        public Task<IEnumerable<ProfessionalInformation>> GetActiveProfessionalInformations();
        public Task<IEnumerable<ProfessionalInformation>> GetProfessionalInformationsByUserId(Guid userId);
        public Task<ProfessionalInformation> CreateProfessionalInformation(ProfessionalInformation professionalInformation);
        public Task<ProfessionalInformation> UpdateProfessionalInformation(ProfessionalInformation professionalInformation);
        public Task<IEnumerable<ProfessionalInformation>> DeleteProfessionalInformation(ProfessionalInformation professionalInformation);
    }
}
