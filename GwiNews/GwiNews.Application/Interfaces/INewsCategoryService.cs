using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.NewsCategory;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface INewsCategoryService
    {
        Task<ResponseModelDTO<IEnumerable<NewsCategory>>> GetNewsCategories();
        Task<ResponseModelDTO<NewsCategory>> GetNewsCategory(Guid id);
        Task<ResponseModelDTO<IEnumerable<NewsCategory>>> GetActiveNewsCategories();
        Task<ResponseModelDTO<NewsCategory>> CreateNewsCategory(CreateNewsCategoryDTO createNewsCategoryDTO);
        Task<ResponseModelDTO<NewsCategory>> UpdateNewsCategory(UpdateNewsCategoryDTO updateNewsCategoryDTO);
        Task<ResponseModelDTO<IEnumerable<NewsCategory>>> DeleteNewsCategory(UpdateNewsCategoryDTO updateNewsCategoryDTO);
    }
}
