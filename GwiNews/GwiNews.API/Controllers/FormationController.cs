using GwiNews.Application.DTOs.FormationDTO;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Formações")]
    [ApiController]
    public class FormationController : ControllerBase
    {
        private readonly IFormationService _formationService;
        public FormationController(IFormationService FormationService)
        {
            _formationService = FormationService;
        }

        [HttpGet("Listar-Formações")]
        public async Task<IActionResult> GetFormations()
        {
            var response = await _formationService.GetFormations();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Formação/{id}")]
        public async Task<IActionResult> GetFormation(Guid id)
        {
            var response = await _formationService.GetFormation(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Formações-Ativas")]
        public async Task<IActionResult> GetActiveFormations()
        {
            var response = await _formationService.GetActiveFormations();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Formações-Por-Usuário/{id}")]
        public async Task<IActionResult> GetFormationsByUserId(Guid id)
        {
            var response = await _formationService.GetFormationsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Formações-Ativas-Por-Usuário/{id}")]
        public async Task<IActionResult> GetActiveFormationsByUserId(Guid id)
        {
            var response = await _formationService.GetActiveFormationsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Formação")]
        public async Task<IActionResult> CreateFormation([FromBody] CreateFormationDTO createFormationDTO)
        {
            var response = await _formationService.CreateFormation(createFormationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Formação")]
        public async Task<IActionResult> UpdateFormation([FromBody] UpdateFormationDTO updateFormationDTO)
        {
            var response = await _formationService.UpdateFormation(updateFormationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Formação")]
        public async Task<IActionResult> DeleteFormation([FromBody] UpdateFormationDTO updateFormationDTO)
        {
            var response = await _formationService.DeleteFormation(updateFormationDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
