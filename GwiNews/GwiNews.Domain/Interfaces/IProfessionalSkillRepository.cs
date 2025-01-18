using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalSkillRepository
    {
        public Task<IEnumerable<ProfessionalSkill>> GetProfessionalSkills();
        public Task<ProfessionalSkill> GetProfessionalSkill(Guid id);
        public Task<IEnumerable<ProfessionalSkill>> GetActiveProfessionalSkills();
        public Task<IEnumerable<ProfessionalSkill>> GetProfessionalSkillsByUserId(Guid userId);
        public Task<IEnumerable<ProfessionalSkill>> GetActiveProfessionalSkillsByUserId(Guid userId);
        public Task<ProfessionalSkill> CreateProfessionalSkill(ProfessionalSkill professionalSkill);
        public Task<ProfessionalSkill> UpdateProfessionalSkill(ProfessionalSkill professionalSkill);
        public Task<IEnumerable<ProfessionalSkill>> DeleteProfessionalSkill(ProfessionalSkill professionalSkill);
    }
}
