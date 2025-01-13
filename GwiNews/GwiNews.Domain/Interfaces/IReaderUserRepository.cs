using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IReaderUserRepository
    {
        public Task<IEnumerable<ReaderUser>> GetReaderUsers();
        public Task<ReaderUser> GetReaderUser(Guid id);
        public Task<IEnumerable<ReaderUser>> GetActiveReaderUsers();
        public Task<ReaderUser> CreateReaderUser(ReaderUser readerUser);
        public Task<ReaderUser> UpdateReaderUser(ReaderUser readerUser);
        public Task<IEnumerable<ReaderUser>> DeleteReaderUser(ReaderUser readerUser);
    }
}
