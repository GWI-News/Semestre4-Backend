using GwiNews.Application.DTOs.NewsSubcategory;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Subcategorias-de-Notícias")]
    [ApiController]
    public class NewsSubcategoryController : ControllerBase
    {
        private readonly INewsSubcategoryService _newsSubcategoryService;
        public NewsSubcategoryController(INewsSubcategoryService newsSubcategoryService)
        {
            _newsSubcategoryService = newsSubcategoryService;
        }

        [HttpGet("Listar-Subcategorias-de-Notícias")]
        public async Task<IActionResult> GetNewsSubcategories()
        {
            var response = await _newsSubcategoryService.GetNewsSubcategories();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Buscar-Subcategoria-de-Notícia/{id}")]
        public async Task<IActionResult> GetNewsSubcategory(Guid id)
        {
            var response = await _newsSubcategoryService.GetNewsSubcategory(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Subcategorias-de-Notícias-por-Categoria/{id}")]
        public async Task<IActionResult> GetNewsSubcategoriesByCategoryId(Guid id)
        {
            var response = await _newsSubcategoryService.GetNewsSubcategoriesByCategoryId(id);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("Listar-Subcategorias-de-Notícias-Ativas")]
        public async Task<IActionResult> GetActiveNewsSubcategories()
        {
            var response = await _newsSubcategoryService.GetActiveNewsSubcategories();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Criar-Subcategoria-de-Notícia")]
        public async Task<IActionResult> CreateNewsSubcategory([FromBody] CreateNewsSubcategoryDTO createNewsSubcategoryDTO)
        {
            var response = await _newsSubcategoryService.CreateNewsSubcategory(createNewsSubcategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Atualizar-Subcategoria-de-Notícia")]
        public async Task<IActionResult> UpdateNewsSubcategory([FromBody] UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO)
        {
            var response = await _newsSubcategoryService.UpdateNewsSubcategory(updateNewsSubcategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Deletar-Subcategoria-de-Notícia")]
        public async Task<IActionResult> DeleteNewsSubcategory([FromBody] UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO)
        {
            var response = await _newsSubcategoryService.DeleteNewsSubcategory(updateNewsSubcategoryDTO);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
