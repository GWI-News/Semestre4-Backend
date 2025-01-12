using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IUserWithNewsRepository
    {
        public Task<IEnumerable<UserWithNews>> GetUsersWithNews();
        public Task<UserWithNews> GetUserWithNews(Guid id);
        public Task<IEnumerable<UserWithNews>> GetActiveUsersWithNews();
        public Task<UserWithNews> CreateUserWithNews(UserWithNews userWithNews);
        public Task<UserWithNews> UpdateUserWithNews(UserWithNews userWithNews);
        public Task<IEnumerable<UserWithNews>> DeleteUserWithNews(UserWithNews userWithNews);
    }
}
