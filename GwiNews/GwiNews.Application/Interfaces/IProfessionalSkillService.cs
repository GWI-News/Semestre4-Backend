using GwiNews.Application.DTOs.ProfessionalSkill;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IProfessionalSkillService
    {
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionalSkills();
        Task<ResponseModelDTO<ProfessionalSkill>> GetProfessionalSkill(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionalSkills();
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionalSkillsByUserId(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionalSkillsByUserId(Guid id);
        Task<ResponseModelDTO<ProfessionalSkill>> CreateProfessionalSkill(CreateProfessionalSkillDTO createProfessionalSkillDTO);
        Task<ResponseModelDTO<ProfessionalSkill>> UpdateProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> DeleteProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO);
    }
}
