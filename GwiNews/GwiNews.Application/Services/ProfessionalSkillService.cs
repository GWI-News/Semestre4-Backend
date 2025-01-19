using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ProfessionalSkill;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class ProfessionalSkillService : IProfessionalSkillService
    {
        private readonly IProfessionalSkillRepository _professionalSkillRepository;
        private readonly IMapper _mapper;
        public ProfessionalSkillService(IProfessionalSkillRepository professionalSkillRepository, IMapper mapper)
        {
            _professionalSkillRepository = professionalSkillRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionalSkills()
        {
            ResponseModelDTO<IEnumerable<ProfessionalSkill>> response = new ResponseModelDTO<IEnumerable<ProfessionalSkill>>();
            try
            {
                var professionalSkills = await _professionalSkillRepository.GetProfessionalSkills();
                response.Data = professionalSkills;
                response.Message = "Habilidades Profissionais Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalSkill>> GetProfessionalSkill(Guid id)
        {
            ResponseModelDTO<ProfessionalSkill> response = new ResponseModelDTO<ProfessionalSkill>();
            try
            {
                var professionalSkill = await _professionalSkillRepository.GetProfessionalSkill(id);
                response.Data = professionalSkill;
                response.Message = "Habilidade Profissional Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionalSkills()
        {
            ResponseModelDTO<IEnumerable<ProfessionalSkill>> response = new ResponseModelDTO<IEnumerable<ProfessionalSkill>>();
            try
            {
                var professionalSkills = await _professionalSkillRepository.GetActiveProfessionalSkills();
                response.Data = professionalSkills;
                response.Message = "Habilidades Profissionais Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetProfessionalSkillsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<ProfessionalSkill>> response = new ResponseModelDTO<IEnumerable<ProfessionalSkill>>();
            try
            {
                var professionalSkills = await _professionalSkillRepository.GetProfessionalSkillsByUserId(userId);
                response.Data = professionalSkills;
                response.Message = "Habilidades Profissionais por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> GetActiveProfessionalSkillsByUserId(Guid userId)
        {
            ResponseModelDTO<IEnumerable<ProfessionalSkill>> response = new ResponseModelDTO<IEnumerable<ProfessionalSkill>>();
            try
            {
                var professionalSkills = await _professionalSkillRepository.GetActiveProfessionalSkillsByUserId(userId);
                response.Data = professionalSkills;
                response.Message = "Habilidades Profissionais por Usuário Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalSkill>> CreateProfessionalSkill(CreateProfessionalSkillDTO createProfessionalSkillDTO)
        {
            ResponseModelDTO<ProfessionalSkill> response = new ResponseModelDTO<ProfessionalSkill>();
            try
            {
                var professionalSkill = _mapper.Map<ProfessionalSkill>(createProfessionalSkillDTO);
                professionalSkill = await _professionalSkillRepository.CreateProfessionalSkill(professionalSkill);
                response.Data = professionalSkill;
                response.Message = "Habilidade Profissional Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<ProfessionalSkill>> UpdateProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO)
        {
            ResponseModelDTO<ProfessionalSkill> response = new ResponseModelDTO<ProfessionalSkill>();
            try
            {
                var professionalSkill = _mapper.Map<ProfessionalSkill>(updateProfessionalSkillDTO);
                var professionalSkillUpdated = await _professionalSkillRepository.UpdateProfessionalSkill(professionalSkill);
                response.Data = professionalSkillUpdated;
                response.Message = "Habilidade Profissional Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<ProfessionalSkill>>> DeleteProfessionalSkill(UpdateProfessionalSkillDTO updateProfessionalSkillDTO)
        {
            ResponseModelDTO<IEnumerable<ProfessionalSkill>> response = new ResponseModelDTO<IEnumerable<ProfessionalSkill>>();
            try
            {
                var professionalSkill = _mapper.Map<ProfessionalSkill>(updateProfessionalSkillDTO);
                var professionalSkillUpdatedDeleted = await _professionalSkillRepository.DeleteProfessionalSkill(professionalSkill);
                response.Data = professionalSkillUpdatedDeleted;
                response.Message = "Habilidade Profissional Deletada com Sucesso.";
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
