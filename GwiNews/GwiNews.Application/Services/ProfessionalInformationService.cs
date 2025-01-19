using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ProfessionalInformation;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class ProfessionalInformationService : IProfessionalInformationService
    {
        private readonly IProfessionalInformationRepository _professionalInformationRepository;
        private readonly IMapper _mapper;
        public ProfessionalInformationService(IProfessionalInformationRepository professionalInformationRepository, IMapper mapper)
        {
            _professionalInformationRepository = professionalInformationRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionalInformations()
        {
            ResponseModelDTO<IEnumerable<ProfessionalInformation>> response = new ResponseModelDTO<IEnumerable<ProfessionalInformation>>();
            try
            {
                var professionalInformations = await _professionalInformationRepository.GetProfessionalInformations();
                response.Data = professionalInformations;
                response.Message = "Informações Profissionais Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalInformation>> GetProfessionalInformation(Guid id)
        {
            ResponseModelDTO<ProfessionalInformation> response = new ResponseModelDTO<ProfessionalInformation>();
            try
            {
                var professionalInformation = await _professionalInformationRepository.GetProfessionalInformation(id);
                response.Data = professionalInformation;
                response.Message = "Informação Profissional Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionalInformations()
        {
            ResponseModelDTO<IEnumerable<ProfessionalInformation>> response = new ResponseModelDTO<IEnumerable<ProfessionalInformation>>();
            try
            {
                var professionalInformations = await _professionalInformationRepository.GetActiveProfessionalInformations();
                response.Data = professionalInformations;
                response.Message = "Informações Profissionais Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetProfessionalInformationsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<ProfessionalInformation>> response = new ResponseModelDTO<IEnumerable<ProfessionalInformation>>();
            try
            {
                var professionalInformations = await _professionalInformationRepository.GetProfessionalInformationsByUserId(userId);
                response.Data = professionalInformations;
                response.Message = "Informações Profissionais por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> GetActiveProfessionalInformationsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<ProfessionalInformation>> response = new ResponseModelDTO<IEnumerable<ProfessionalInformation>>();
            try
            {
                var professionalInformations = await _professionalInformationRepository.GetActiveProfessionalInformationsByUserId(userId);
                response.Data = professionalInformations;
                response.Message = "Informações Profissionais por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalInformation>> CreateProfessionalInformation(CreateProfessionalInformationDTO createProfessionalInformationDTO)
        {
            ResponseModelDTO<ProfessionalInformation> response = new ResponseModelDTO<ProfessionalInformation>();
            try
            {
                var professionalInformation = _mapper.Map<ProfessionalInformation>(createProfessionalInformationDTO);
                professionalInformation = await _professionalInformationRepository.CreateProfessionalInformation(professionalInformation);
                response.Data = professionalInformation;
                response.Message = "Informação Profissional Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalInformation>> UpdateProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO)
        {
            ResponseModelDTO<ProfessionalInformation> response = new ResponseModelDTO<ProfessionalInformation>();
            try
            {
                var professionalInformation = _mapper.Map<ProfessionalInformation>(updateProfessionalInformationDTO);
                var professionalInformationUpdated = await _professionalInformationRepository.UpdateProfessionalInformation(professionalInformation);
                response.Data = professionalInformationUpdated;
                response.Message = "Informação Profissional Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalInformation>>> DeleteProfessionalInformation(UpdateProfessionalInformationDTO updateProfessionalInformationDTO)
        {
            ResponseModelDTO<IEnumerable<ProfessionalInformation>> response = new ResponseModelDTO<IEnumerable<ProfessionalInformation>>();
            try
            {
                var professionalInformation = _mapper.Map<ProfessionalInformation>(updateProfessionalInformationDTO);
                var professionalInformationUpdatedDeleted = await _professionalInformationRepository.DeleteProfessionalInformation(professionalInformation);
                response.Data = professionalInformationUpdatedDeleted;
                response.Message = "Informação Profissional Deletada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
