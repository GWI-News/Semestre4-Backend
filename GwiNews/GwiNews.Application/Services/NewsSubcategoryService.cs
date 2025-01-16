using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.NewsSubcategory;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class NewsSubcategoryService : INewsSubcategoryService
    {
        private readonly INewsSubcategoryRepository _newsSubcategoryRepository;
        private readonly IMapper _mapper;
        public NewsSubcategoryService(INewsSubcategoryRepository newsSubcategoryRepository, IMapper mapper)
        {
            _newsSubcategoryRepository = newsSubcategoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetNewsSubcategories()
        {
            ResponseModelDTO<IEnumerable<NewsSubcategory>> response = new ResponseModelDTO<IEnumerable<NewsSubcategory>>();
            try
            {
                var newsSubcategories = await _newsSubcategoryRepository.GetNewsSubcategories();
                response.Data = newsSubcategories;
                response.Message = "Subcategorias de Notícias Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsSubcategory>> GetNewsSubcategory(Guid id)
        {
            ResponseModelDTO<NewsSubcategory> response = new ResponseModelDTO<NewsSubcategory>();
            try
            {
                var newsSubcategory = await _newsSubcategoryRepository.GetNewsSubcategory(id);
                response.Data = newsSubcategory;
                response.Message = "Subcategoria de Notícia Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetNewsSubcategoriesByCategoryId(Guid id)
        {
            ResponseModelDTO<IEnumerable<NewsSubcategory>> response = new ResponseModelDTO<IEnumerable<NewsSubcategory>>();
            try
            {
                var newsSubcategories = await _newsSubcategoryRepository.GetNewsSubcategoriesByCategoryId(id);
                response.Data = newsSubcategories;
                response.Message = "Subcategorias de Notícias por Categoria Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetActiveNewsSubcategories()
        {
            ResponseModelDTO<IEnumerable<NewsSubcategory>> response = new ResponseModelDTO<IEnumerable<NewsSubcategory>>();
            try
            {
                var newsSubcategories = await _newsSubcategoryRepository.GetActiveNewsSubcategories();
                response.Data = newsSubcategories;
                response.Message = "Subcategorias de Notícias Ativas Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsSubcategory>> CreateNewsSubcategory(CreateNewsSubcategoryDTO createNewsSubcategoryDTO)
        {
            ResponseModelDTO<NewsSubcategory> response = new ResponseModelDTO<NewsSubcategory>();
            try
            {
                var newsSubcategory = _mapper.Map<NewsSubcategory>(createNewsSubcategoryDTO);
                var newsSubcategoryCreated = await _newsSubcategoryRepository.CreateNewsSubcategory(newsSubcategory);
                response.Data = newsSubcategoryCreated;
                response.Message = "Subcategoria de Notícia Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsSubcategory>> UpdateNewsSubcategory(UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO)
        {
            ResponseModelDTO<NewsSubcategory> response = new ResponseModelDTO<NewsSubcategory>();
            try
            {
                var newsSubcategory = _mapper.Map<NewsSubcategory>(updateNewsSubcategoryDTO);
                var newsSubcategoryUpdated = await _newsSubcategoryRepository.UpdateNewsSubcategory(newsSubcategory);
                response.Data = newsSubcategoryUpdated;
                response.Message = "Subcategoria de Notícia Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> DeleteNewsSubcategory(UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO)
        {
            ResponseModelDTO<IEnumerable<NewsSubcategory>> response = new ResponseModelDTO<IEnumerable<NewsSubcategory>>();
            try
            {
                var newsSubcategory = _mapper.Map<NewsSubcategory>(updateNewsSubcategoryDTO);
                var newsSubcategories = await _newsSubcategoryRepository.DeleteNewsSubcategory(newsSubcategory);
                response.Data = newsSubcategories;
                response.Message = "Subcategoria de Notícia Excluída com Sucesso.";
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
