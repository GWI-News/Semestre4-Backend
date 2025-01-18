using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.FormationDTO;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class FormationService : IFormationService
    {
        private readonly IFormationRepository _FormationRepository;
        private readonly IMapper _mapper;
        public FormationService(IFormationRepository FormationRepository, IMapper mapper)
        {
            _FormationRepository = FormationRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<Formation>>> GetFormations()
        {
            ResponseModelDTO<IEnumerable<Formation>> response = new ResponseModelDTO<IEnumerable<Formation>>();
            try
            {
                var formations = await _FormationRepository.GetFormations();
                response.Data = formations;
                response.Message = "Formações Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<Formation>> GetFormation(Guid id)
        {
            ResponseModelDTO<Formation> response = new ResponseModelDTO<Formation>();
            try
            {
                var formation = await _FormationRepository.GetFormation(id);
                response.Data = formation;
                response.Message = "Formação Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<Formation>>> GetActiveFormations()
        {
            ResponseModelDTO<IEnumerable<Formation>> response = new ResponseModelDTO<IEnumerable<Formation>>();
            try
            {
                var formations = await _FormationRepository.GetActiveFormations();
                response.Data = formations;
                response.Message = "Formações Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<Formation>>> GetFormationsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<Formation>> response = new ResponseModelDTO<IEnumerable<Formation>>();
            try
            {
                var formations = await _FormationRepository.GetFormationsByUserId(userId);
                response.Data = formations;
                response.Message = "Formações por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<Formation>>> GetActiveFormationsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<Formation>> response = new ResponseModelDTO<IEnumerable<Formation>>();
            try
            {
                var formations = await _FormationRepository.GetActiveFormationsByUserId(userId);
                response.Data = formations;
                response.Message = "Formações por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<Formation>> CreateFormation(CreateFormationDTO createFormationDTO)
        {
            ResponseModelDTO<Formation> response = new ResponseModelDTO<Formation>();
            try
            {
                var formation = _mapper.Map<Formation>(createFormationDTO);
                formation = await _FormationRepository.CreateFormation(formation);
                response.Data = formation;
                response.Message = "Formação Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<Formation>> UpdateFormation(UpdateFormationDTO updateFormationDTO)
        {
            ResponseModelDTO<Formation> response = new ResponseModelDTO<Formation>();
            try
            {
                var formation = _mapper.Map<Formation>(updateFormationDTO);
                var formationUpdated = await _FormationRepository.UpdateFormation(formation);
                response.Data = formationUpdated;
                response.Message = "Formação Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<Formation>>> DeleteFormation(UpdateFormationDTO updateFormationDTO)
        {
            ResponseModelDTO<IEnumerable<Formation>> response = new ResponseModelDTO<IEnumerable<Formation>>();
            try
            {
                var formation = _mapper.Map<Formation>(updateFormationDTO);
                var formationUpdatedDeleted = await _FormationRepository.DeleteFormation(formation);
                response.Data = formationUpdatedDeleted;
                response.Message = "Formação Deletada com Sucesso.";
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
