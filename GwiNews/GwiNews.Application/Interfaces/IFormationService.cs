using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.FormationDTO;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IFormationService
    {
        Task<ResponseModelDTO<IEnumerable<Formation>>> GetFormations();
        Task<ResponseModelDTO<Formation>> GetFormation(Guid id);
        Task<ResponseModelDTO<IEnumerable<Formation>>> GetActiveFormations();
        Task<ResponseModelDTO<IEnumerable<Formation>>> GetFormationsByUserId(Guid id);
        Task<ResponseModelDTO<IEnumerable<Formation>>> GetActiveFormationsByUserId(Guid id);
        Task<ResponseModelDTO<Formation>> CreateFormation(CreateFormationDTO createFormationDTO);
        Task<ResponseModelDTO<Formation>> UpdateFormation(UpdateFormationDTO updateFormationDTO);
        Task<ResponseModelDTO<IEnumerable<Formation>>> DeleteFormation(UpdateFormationDTO updateFormationDTO);
    }
}
