using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.ReaderUser;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class ReaderUserService : IReaderUserService
    {
        private readonly IReaderUserRepository _readerUserRepository;
        private readonly IMapper _mapper;
        public ReaderUserService(IReaderUserRepository readerUserRepository, IMapper mapper)
        {
            _readerUserRepository = readerUserRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModelDTO<IEnumerable<ReaderUser>>> GetReaderUsers()
        {
            ResponseModelDTO<IEnumerable<ReaderUser>> response = new ResponseModelDTO<IEnumerable<ReaderUser>>();
            try
            {
                var readerUsers = await _readerUserRepository.GetReaderUsers();
                response.Data = readerUsers;
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

        public async Task<ResponseModelDTO<ReaderUser>> GetReaderUser(Guid id)
        {
            ResponseModelDTO<ReaderUser> response = new ResponseModelDTO<ReaderUser>();
            try
            {
                var readerUser = await _readerUserRepository.GetReaderUser(id);
                response.Data = readerUser;
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

        public async Task<ResponseModelDTO<IEnumerable<ReaderUser>>> GetActiveReaderUsers()
        {
            ResponseModelDTO<IEnumerable<ReaderUser>> response = new ResponseModelDTO<IEnumerable<ReaderUser>>();
            try
            {
                var readerUsers = await _readerUserRepository.GetActiveReaderUsers();
                response.Data = readerUsers;
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

        public async Task<ResponseModelDTO<ReaderUser>> CreateReaderUser(CreateReaderUserDTO createReaderUserDTO)
        {
            ResponseModelDTO<ReaderUser> response = new ResponseModelDTO<ReaderUser>();
            try
            {
                var readerUser = _mapper.Map<ReaderUser>(createReaderUserDTO);
                var createdReaderUser = await _readerUserRepository.CreateReaderUser(readerUser);
                response.Data = createdReaderUser;
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

        public async Task<ResponseModelDTO<ReaderUser>> UpdateReaderUser(UpdateReaderUserDTO updateReaderUserDTO)
        {
            ResponseModelDTO<ReaderUser> response = new ResponseModelDTO<ReaderUser>();
            try
            {
                var readerUser = _mapper.Map<ReaderUser>(updateReaderUserDTO);
                var updatedReaderUser = await _readerUserRepository.UpdateReaderUser(readerUser);
                response.Data = updatedReaderUser;
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

        public async Task<ResponseModelDTO<IEnumerable<ReaderUser>>> DeleteReaderUser(UpdateReaderUserDTO updateReaderUserDTO)
        {
            ResponseModelDTO<IEnumerable<ReaderUser>> response = new ResponseModelDTO<IEnumerable<ReaderUser>>();
            try
            {
                var readerUser = _mapper.Map<ReaderUser>(updateReaderUserDTO);
                var deletedReaderUser = await _readerUserRepository.DeleteReaderUser(readerUser);
                response.Data = deletedReaderUser;
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
