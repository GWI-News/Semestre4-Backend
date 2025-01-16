using GwiNews.Application.DTOs.NewsCategory;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Categorias-de-Notícias")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly INewsCategoryService _newsCategoryService;
        public NewsCategoryController(INewsCategoryService newsCategoryService)
        {
            _newsCategoryService = newsCategoryService;
        }

        [HttpGet("Listar-Categorias-de-Notícias")]
        public async Task<IActionResult> GetNewsCategories()
        {
            var response = await _newsCategoryService.GetNewsCategories();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Categoria-de-Notícia/{id}")]
        public async Task<IActionResult> GetNewsCategory(Guid id)
        {
            var response = await _newsCategoryService.GetNewsCategory(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Categorias-de-Notícias-Ativas")]
        public async Task<IActionResult> GetActiveNewsCategories()
        {
            var response = await _newsCategoryService.GetActiveNewsCategories();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Categoria-de-Notícia")]
        public async Task<IActionResult> CreateNewsCategory([FromBody] CreateNewsCategoryDTO createNewsCategoryDTO)
        {
            var response = await _newsCategoryService.CreateNewsCategory(createNewsCategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Categoria-de-Notícia")]
        public async Task<IActionResult> UpdateNewsCategory([FromBody] UpdateNewsCategoryDTO updateNewsCategoryDTO)
        {
            var response = await _newsCategoryService.UpdateNewsCategory(updateNewsCategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Categoria-de-Notícia")]
        public async Task<IActionResult> DeleteNewsCategory([FromBody] UpdateNewsCategoryDTO updateNewsCategoryDTO)
        {
            var response = await _newsCategoryService.DeleteNewsCategory(updateNewsCategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
