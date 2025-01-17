using GwiNews.Application.DTOs.ProfessionalInformation;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Informações-Profissionais")]
    [ApiController]
    public class ProfessionalInformationController : ControllerBase
    {
        private readonly IProfessionalInformationService _professionalInformationService;
        public ProfessionalInformationController(IProfessionalInformationService professionalInformationService)
        {
            _professionalInformationService = professionalInformationService;
        }

        [HttpGet("Listar-Informações-Profissionais")]
        public async Task<IActionResult> GetProfessionalInformations()
        {
            var response = await _professionalInformationService.GetProfessionaInformations();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Informação-Profissional/{id}")]
        public async Task<IActionResult> GetProfessionalInformation(Guid id)
        {
            var response = await _professionalInformationService.GetProfessionaInformation(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Informações-Profissionais-Ativas")]
        public async Task<IActionResult> GetActiveProfessionalInformations()
        {
            var response = await _professionalInformationService.GetActiveProfessionaInformations();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Informações-Profissionais-Por-Usuário/{id}")]
        public async Task<IActionResult> GetProfessionalInformationsByUserId(Guid id)
        {
            var response = await _professionalInformationService.GetProfessionaInformationsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Informações-Profissionais-Ativas-Por-Usuário/{id}")]
        public async Task<IActionResult> GetActiveProfessionalInformationsByUserId(Guid id)
        {
            var response = await _professionalInformationService.GetActiveProfessionaInformationsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Informação-Profissional")]
        public async Task<IActionResult> CreateProfessionalInformation([FromBody] CreateProfessionalInformationDTO createProfessionalInformationDTO)
        {
            var response = await _professionalInformationService.CreateProfessionalInformation(createProfessionalInformationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Informação-Profissional")]
        public async Task<IActionResult> UpdateProfessionalInformation([FromBody] UpdateProfessionalInformationDTO updateProfessionalInformationDTO)
        {
            var response = await _professionalInformationService.UpdateProfessionalInformation(updateProfessionalInformationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Informação-Profissional")]
        public async Task<IActionResult> DeleteProfessionalInformation([FromBody] UpdateProfessionalInformationDTO updateProfessionalInformationDTO)
        {
            var response = await _professionalInformationService.DeleteProfessionalInformation(updateProfessionalInformationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
