using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ReaderUser;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IReaderUserService
    {
        public Task<ResponseModelDTO<IEnumerable<ReaderUser>>> GetReaderUsers();
        public Task<ResponseModelDTO<ReaderUser>> GetReaderUser(Guid id);
        public Task<ResponseModelDTO<IEnumerable<ReaderUser>>> GetActiveReaderUsers();
        public Task<ResponseModelDTO<ReaderUser>> CreateReaderUser(CreateReaderUserDTO createReaderUserDTO);
        public Task<ResponseModelDTO<ReaderUser>> UpdateReaderUser(UpdateReaderUserDTO updateReaderUserDTO);
        public Task<ResponseModelDTO<IEnumerable<ReaderUser>>> DeleteReaderUser(UpdateReaderUserDTO updateReaderUserDTO);
    }
}
