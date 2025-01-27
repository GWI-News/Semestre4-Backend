using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IFirestoreToSqlServerDataStreamingService
    {
        public Task<ResponseModelDTO<bool>> DataStreamingCaller();
        public Task<ResponseModelDTO<bool>> UserWithNewsDataStreaming();
        public Task<ResponseModelDTO<bool>> NewsCategoryDataStreaming();
        public Task<ResponseModelDTO<bool>> NewsSubcategoryDataStreaming();
        public Task<ResponseModelDTO<bool>> NewsDataStreaming();
        public Task<ResponseModelDTO<bool>> ReaderUserDataStreaming();
        public Task<ResponseModelDTO<bool>> ProfessionalInformationDataStreaming();
        public Task<ResponseModelDTO<bool>> ProfessionalSkillNewsDataStreaming();
        public Task<ResponseModelDTO<bool>> FormationNewsDataStreaming();
    }
}
