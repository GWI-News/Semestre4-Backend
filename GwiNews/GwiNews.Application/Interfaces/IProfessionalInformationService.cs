using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ProfessionalInformation;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IProfessionalInformationService
    {
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionaInformations();
        Task<ResponseModelDTO<ProfessionalInformation>> GetProfessionaInformation(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionaInformations();
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionaInformationsByUserId(Guid id);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionaInformationsByUserId(Guid id);
        Task<ResponseModelDTO<ProfessionalInformation>> CreateProfessionalInformation(CreateProfessionalInformationDTO createProfessionalInformationDTO);
        Task<ResponseModelDTO<ProfessionalInformation>> UpdateProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO);
        Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> DeleteProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO);
    }
}
