using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class UserWithNewsService : IUserWithNewsService
    {
        private IUserWithNewsRepository _repository;
        private IMapper _mapper;
        public UserWithNewsService(IUserWithNewsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<UserWithNews>>> GetUsersWithNews()
        {
            ResponseModelDTO<IEnumerable<UserWithNews>> response = new ResponseModelDTO<IEnumerable<UserWithNews>>();
            try
            {
                var usersWithNews = await _repository.GetUsersWithNews();
                response.Data = usersWithNews;
                response.Message = "Usuários Listados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<UserWithNews>> GetUserWithNews(Guid id)
        {
            ResponseModelDTO<UserWithNews> response = new ResponseModelDTO<UserWithNews>();
            try
            {
                var userWithNews = await _repository.GetUserWithNews(id);
                response.Data = userWithNews;
                response.Message = "Usuário Listado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<UserWithNews>>> GetActiveUsersWithNews()
        {
            ResponseModelDTO<IEnumerable<UserWithNews>> response = new ResponseModelDTO<IEnumerable<UserWithNews>>();
            try
            {
                var usersWithNews = await _repository.GetActiveUsersWithNews();
                response.Data = usersWithNews;
                response.Message = "Usuários Ativos Listados com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<UserWithNews>> CreateUserWithNews(CreateUserWithNewsDTO createUserWithNewsDTO)
        {
            ResponseModelDTO<UserWithNews> response = new ResponseModelDTO<UserWithNews>();
            try
            {
                var userWithNews = _mapper.Map<UserWithNews>(createUserWithNewsDTO);
                var userWithNewsCreated = await _repository.CreateUserWithNews(userWithNews);
                response.Data = userWithNewsCreated;
                response.Message = "Usuário Criado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<UserWithNews>> UpdateUserWithNews(UpdateUserWithNewsDTO updateUserWithNewsDTO)
        {
            ResponseModelDTO<UserWithNews> response = new ResponseModelDTO<UserWithNews>();
            try
            {
                var userWithNews = _mapper.Map<UserWithNews>(updateUserWithNewsDTO);
                var userWithNewsUpdated = await _repository.UpdateUserWithNews(userWithNews);
                response.Data = userWithNewsUpdated;
                response.Message = "Usuário Atualizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<IEnumerable<UserWithNews>>> DeleteUserWithNews(UpdateUserWithNewsDTO updateUserWithNewsDTO)
        {
            ResponseModelDTO<IEnumerable<UserWithNews>> response = new ResponseModelDTO<IEnumerable<UserWithNews>>();
            try
            {
                var userWithNews = _mapper.Map<UserWithNews>(updateUserWithNewsDTO);
                var usersWithNews = await _repository.DeleteUserWithNews(userWithNews);
                response.Data = usersWithNews;
                response.Message = "Usuário Deletado com Sucesso.";
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
