using GwiNews.Application.DTOs.ProfessionalSkill;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IProfessionalSkillService
    {
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionaSkills();
        Task<ResponseModelDTO<ProfessionalSkill>> GetProfessionaSkill(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionaSkills();
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionaSkillsByUserId(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionaSkillsByUserId(Guid id);
        Task<ResponseModelDTO<ProfessionalSkill>> CreateProfessionalSkill(CreateProfessionalSkillDTO createProfessionalSkillDTO);
        Task<ResponseModelDTO<ProfessionalSkill>> UpdateProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO);
        Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> DeleteProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO);
    }
}
