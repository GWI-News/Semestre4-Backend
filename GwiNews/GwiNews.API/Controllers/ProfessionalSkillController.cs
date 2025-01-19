using GwiNews.Application.DTOs.ProfessionalSkill;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Habilidades-Profissionais")]
    [ApiController]
    public class ProfessionalSkillController : ControllerBase
    {
        private readonly IProfessionalSkillService _professionalSkillService;
        public ProfessionalSkillController(IProfessionalSkillService professionalSkillService)
        {
            _professionalSkillService = professionalSkillService;
        }

        [HttpGet("Listar-Habilidades-Profissionais")]
        public async Task<IActionResult> GetProfessionalSkills()
        {
            var response = await _professionalSkillService.GetProfessionalSkills();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Habilidade-Profissional/{id}")]
        public async Task<IActionResult> GetProfessionalSkill(Guid id)
        {
            var response = await _professionalSkillService.GetProfessionalSkill(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Habilidades-Profissionais-Ativas")]
        public async Task<IActionResult> GetActiveProfessionalSkills()
        {
            var response = await _professionalSkillService.GetActiveProfessionalSkills();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Habilidades-Profissionais-Por-Usuário/{id}")]
        public async Task<IActionResult> GetProfessionalSkillsByUserId(Guid id)
        {
            var response = await _professionalSkillService.GetProfessionalSkillsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Habilidades-Profissionais-Ativas-Por-Usuário/{id}")]
        public async Task<IActionResult> GetActiveProfessionalSkillsByUserId(Guid id)
        {
            var response = await _professionalSkillService.GetActiveProfessionalSkillsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Habilidade-Profissional")]
        public async Task<IActionResult> CreateProfessionalSkill([FromBody] CreateProfessionalSkillDTO createProfessionalSkillDTO)
        {
            var response = await _professionalSkillService.CreateProfessionalSkill(createProfessionalSkillDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Habilidade-Profissional")]
        public async Task<IActionResult> UpdateProfessionalSkill([FromBody] UpdateProfessionalSkillDTO updateProfessionalSkillDTO)
        {
            var response = await _professionalSkillService.UpdateProfessionalSkill(updateProfessionalSkillDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Habilidade-Profissional")]
        public async Task<IActionResult> DeleteProfessionalSkill([FromBody] UpdateProfessionalSkillDTO updateProfessionalSkillDTO)
        {
            var response = await _professionalSkillService.DeleteProfessionalSkill(updateProfessionalSkillDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
