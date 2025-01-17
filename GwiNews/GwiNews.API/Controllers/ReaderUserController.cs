using GwiNews.Application.DTOs.ReaderUser;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Usuários-Leitores")]
    [ApiController]
    public class ReaderUserController : ControllerBase
    {
        private readonly IReaderUserService _readerUserService;
        public ReaderUserController(IReaderUserService readerUserService)
        {
            _readerUserService = readerUserService;
        }

        [HttpGet("Listar-Usuários-Leitores")]
        public async Task<IActionResult> GetReaderUsers()
        {
            var response = await _readerUserService.GetReaderUsers();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Usuário-Leitor/{id}")]
        public async Task<IActionResult> GetReaderUserById(Guid id)
        {
            var response = await _readerUserService.GetReaderUser(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Usuários-Leitores-Ativos")]
        public async Task<IActionResult> GetActiveReaderUsers()
        {
            var response = await _readerUserService.GetActiveReaderUsers();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Usuário-Leitor")]
        public async Task<IActionResult> CreateReaderUser([FromBody] CreateReaderUserDTO createReaderUserDTO)
        {
            var response = await _readerUserService.CreateReaderUser(createReaderUserDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Usuário-Leitor")]
        public async Task<IActionResult> UpdateReaderUser([FromBody] UpdateReaderUserDTO updateReaderUserDTO)
        {
            var response = await _readerUserService.UpdateReaderUser(updateReaderUserDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Usuário-Leitor")]
        public async Task<IActionResult> DeleteReaderUser([FromBody] UpdateReaderUserDTO updateReaderUserDTO)
        {
            var response = await _readerUserService.DeleteReaderUser(updateReaderUserDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
