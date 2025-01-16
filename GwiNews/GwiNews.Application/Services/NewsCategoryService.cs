using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.NewsCategory;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class NewsCategoryService : INewsCategoryService
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IMapper _mapper;

        public NewsCategoryService(INewsCategoryRepository newsCategoryRepository, IMapper mapper)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsCategory>>> GetNewsCategories()
        {
            ResponseModelDTO<IEnumerable<NewsCategory>> response = new ResponseModelDTO<IEnumerable<NewsCategory>>();
            try
            {
                var newsCategories = await _newsCategoryRepository.GetNewsCategories();
                response.Data = newsCategories;
                response.Message = "Categorias de Notícias Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsCategory>> GetNewsCategory(Guid id)
        {
            ResponseModelDTO<NewsCategory> response = new ResponseModelDTO<NewsCategory>();
            try
            {
                var newsCategory = await _newsCategoryRepository.GetNewsCategory(id);
                response.Data = newsCategory;
                response.Message = "Categoria de Notícia Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsCategory>>> GetActiveNewsCategories()
        {
            ResponseModelDTO<IEnumerable<NewsCategory>> response = new ResponseModelDTO<IEnumerable<NewsCategory>>();
            try
            {
                var newsCategories = await _newsCategoryRepository.GetActiveNewsCategories();
                response.Data = newsCategories;
                response.Message = "Categorias de Notícias Ativas Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsCategory>> CreateNewsCategory(CreateNewsCategoryDTO createNewsCategoryDTO)
        {
            ResponseModelDTO<NewsCategory> response = new ResponseModelDTO<NewsCategory>();
            try
            {
                var newsCategory = _mapper.Map<NewsCategory>(createNewsCategoryDTO);
                newsCategory = await _newsCategoryRepository.CreateNewsCategory(newsCategory);
                response.Data = newsCategory;
                response.Message = "Categoria de Notícia Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<NewsCategory>> UpdateNewsCategory(UpdateNewsCategoryDTO updateNewsCategoryDTO)
        {
            ResponseModelDTO<NewsCategory> response = new ResponseModelDTO<NewsCategory>();
            try
            {
                var newsCategory = _mapper.Map<NewsCategory>(updateNewsCategoryDTO);
                newsCategory = await _newsCategoryRepository.UpdateNewsCategory(newsCategory);
                response.Data = newsCategory;
                response.Message = "Categoria de Notícia Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<NewsCategory>>> DeleteNewsCategory(UpdateNewsCategoryDTO updateNewsCategoryDTO)
        {
            ResponseModelDTO<IEnumerable<NewsCategory>> response = new ResponseModelDTO<IEnumerable<NewsCategory>>();
            try
            {
                var newsCategory = _mapper.Map<NewsCategory>(updateNewsCategoryDTO);
                var newsCategories = await _newsCategoryRepository.DeleteNewsCategory(newsCategory);
                response.Data = newsCategories;
                response.Message = "Categoria de Notícia Excluída com Sucesso.";
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
