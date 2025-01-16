using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IUserWithNewsService
    {
        public Task<ResponseModelDTO<IEnumerable<UserWithNews>>> GetUsersWithNews();
        public Task<ResponseModelDTO<UserWithNews>> GetUserWithNews(Guid id);
        public Task<ResponseModelDTO<IEnumerable<UserWithNews>>> GetActiveUsersWithNews();
        public Task<ResponseModelDTO<UserWithNews>> CreateUserWithNews(CreateUserWithNewsDTO createUserWithNewsDTO);
        public Task<ResponseModelDTO<UserWithNews>> UpdateUserWithNews(UpdateUserWithNewsDTO updateUserWithNewsDTO);
        public Task<ResponseModelDTO<IEnumerable<UserWithNews>>> DeleteUserWithNews(UpdateUserWithNewsDTO updateUserWithNewsDTO);
    }
}
