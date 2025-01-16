using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithNewsController : ControllerBase
    {
        private readonly IUserWithNewsService _userWithNewsService;
        public UserWithNewsController(IUserWithNewsService userWithNewsService)
        {
            _userWithNewsService = userWithNewsService;
        }

        [HttpGet("Listar-Usuários-com-Notícias")]
        public async Task<IActionResult> GetUsersWithNews()
        {
            var response = await _userWithNewsService.GetUsersWithNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Usuário-com-Notícias/{id}")]
        public async Task<IActionResult> GetUserWithNews(Guid id)
        {
            var response = await _userWithNewsService.GetUserWithNews(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Usuários-Ativos-com-Notícias")]
        public async Task<IActionResult> GetActiveUsersWithNews()
        {
            var response = await _userWithNewsService.GetActiveUsersWithNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Usuário-com-Notícias")]
        public async Task<IActionResult> CreateUserWithNews([FromBody] CreateUserWithNewsDTO createUserWithNewsDTO)
        {
            var response = await _userWithNewsService.CreateUserWithNews(createUserWithNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Usuário-com-Notícias")]
        public async Task<IActionResult> UpdateUserWithNews([FromBody] UpdateUserWithNewsDTO updateUserWithNewsDTO)
        {
            var response = await _userWithNewsService.UpdateUserWithNews(updateUserWithNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Usuário-com-Notícias")]
        public async Task<IActionResult> DeleteUserWithNews([FromBody] UpdateUserWithNewsDTO updateUserWithNewsDTO)
        {
            var response = await _userWithNewsService.DeleteUserWithNews(updateUserWithNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
