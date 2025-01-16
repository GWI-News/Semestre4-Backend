using GwiNews.Application.DTOs.News;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Notícias")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("Listar-Notícias")]
        public async Task<IActionResult> GetNews()
        {
            var response = await _newsService.GetNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Notícia/{id}")]
        public async Task<IActionResult> GetNewsById(Guid id)
        {
            var response = await _newsService.GetNewsById(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-Favoritas-por-Usuário/{id}")]
        public async Task<IActionResult> GetFavoritedNewsByUserId(Guid id)
        {
            var response = await _newsService.GetFavoritedNewsByUserId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-Publicadas")]
        public async Task<IActionResult> GetPublishedNews()
        {
            var response = await _newsService.GetPublishedNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-Publicadas-por-Autor/{id}")]
        public async Task<IActionResult> GetPublishedNewsByAuthorId(Guid id)
        {
            var response = await _newsService.GetPublishedNewsByAuthorId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-Publicadas-por-Editor/{id}")]
        public async Task<IActionResult> GetPublishedNewsByEditorId(Guid id)
        {
            var response = await _newsService.GetPublishedNewsByEditorId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Rascunhos-de-Notícia")]
        public async Task<IActionResult> GetDraftNews()
        {
            var response = await _newsService.GetDraftNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Rascunhos-de-Notícia-por-Autor/{id}")]
        public async Task<IActionResult> GetDraftNewsByAuthorId(Guid id)
        {
            var response = await _newsService.GetDraftNewsByAuthorId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-em-Revisão")]
        public async Task<IActionResult> GetInRevisionNews()
        {
            var response = await _newsService.GetInRevisionNews();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Notícias-em-Revisão-por-Editor/{id}")]
        public async Task<IActionResult> GetInRevisionNewsByEditorId(Guid id)
        {
            var response = await _newsService.GetInRevisionNewsByEditorId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Notícia")]
        public async Task<IActionResult> CreateNews([FromBody] CreateNewsDTO createNewsDTO)
        {
            var response = await _newsService.CreateNews(createNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Notícia")]
        public async Task<IActionResult> UpdateNews([FromBody] UpdateNewsDTO updateNewsDTO)
        {
            var response = await _newsService.UpdateNews(updateNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Notícia")]
        public async Task<IActionResult> DeleteNews([FromBody] UpdateNewsDTO updateNewsDTO)
        {
            var response = await _newsService.DeleteNews(updateNewsDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
