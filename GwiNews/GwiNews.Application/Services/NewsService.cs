using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.News;
using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;
        private readonly IMapper _mapper;
        public NewsService(INewsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetNews()
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetNews();
                response.Data = news;
                response.Message = "Notícias Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<News>> GetNewsById(Guid id)
        {
            ResponseModelDTO<News> response = new ResponseModelDTO<News>();
            try
            {
                var news = await _repository.GetNewsById(id);
                response.Data = news;
                response.Message = "Notícia Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetFavoritedNewsByUserId(Guid id)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetFavoritedNewsByUserId(id);
                response.Data = news;
                response.Message = "Notícia Listada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNews()
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetPublishedNews();
                response.Data = news;
                response.Message = "Notícias Publicadas Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNewsByAuthorId(Guid id)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetPublishedNewsByAuthorId(id);
                response.Data = news;
                response.Message = "Notícias Publicadas por Autor Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetPublishedNewsByEditorId(Guid id)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetPublishedNewsByEditorId(id);
                response.Data = news;
                response.Message = "Notícias Publicadas por Editor Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetDraftNews()
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetDraftNews();
                response.Data = news;
                response.Message = "Rascunhos de Notícias Listados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetDraftNewsByAuthorId(Guid id)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetDraftNewsByAuthorId(id);
                response.Data = news;
                response.Message = "Rascunhos de Notícia por Autor Listados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetInRevisionNews()
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetInRevisionNews();
                response.Data = news;
                response.Message = "Notícias em Revisão Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> GetInRevisionNewsByEditorId(Guid id)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = await _repository.GetInRevisionNewsByEditorId(id);
                response.Data = news;
                response.Message = "Notícias em Revisão por Editor Listadas com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<News>> CreateNews(CreateNewsDTO createNewsDTO)
        {
            ResponseModelDTO<News> response = new ResponseModelDTO<News>();
            try
            {
                var news = _mapper.Map<News>(createNewsDTO);
                var newsCreated = await _repository.CreateNews(news);
                response.Data = newsCreated;
                response.Message = "Notícia Criada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<News>> UpdateNews(UpdateNewsDTO updateNewsDTO)
        {
            ResponseModelDTO<News> response = new ResponseModelDTO<News>();
            try
            {
                var news = _mapper.Map<News>(updateNewsDTO);
                var newsUpdated = await _repository.UpdateNews(news);
                response.Data = newsUpdated;
                response.Message = "Notícia Atualizada com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<News>>> DeleteNews(UpdateNewsDTO updateNewsDTO)
        {
            ResponseModelDTO<IEnumerable<News>> response = new ResponseModelDTO<IEnumerable<News>>();
            try
            {
                var news = _mapper.Map<News>(updateNewsDTO);
                var newsResponse = await _repository.DeleteNews(news);
                response.Data = newsResponse;
                response.Message = "Notícia Deletada com Sucesso.";
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
