using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ProfessionalInformation;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IProfessionalInformationService
    {
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionalInformations();
        Task<ResponseModelDTO<ProfessionalInformation>> GetProfessionalInformation(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionalInformations();
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionalInformationsByUserId(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionalInformationsByUserId(Guid id);
        Task<ResponseModelDTO<ProfessionalInformation>> CreateProfessionalInformation(CreateProfessionalInformationDTO createProfessionalInformationDTO);
        Task<ResponseModelDTO<ProfessionalInformation>> UpdateProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> DeleteProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO);
    }
}
