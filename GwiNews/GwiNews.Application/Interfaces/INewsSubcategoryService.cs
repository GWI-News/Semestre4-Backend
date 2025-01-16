using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.NewsSubcategory;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface INewsSubcategoryService
    {
        Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetNewsSubcategories();
        Task<ResponseModelDTO<NewsSubcategory>> GetNewsSubcategory(Guid id);
        Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetNewsSubcategoriesByCategoryId(Guid id);
        Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> GetActiveNewsSubcategories();
        Task<ResponseModelDTO<NewsSubcategory>> CreateNewsSubcategory(CreateNewsSubcategoryDTO createNewsSubcategoryDTO);
        Task<ResponseModelDTO<NewsSubcategory>> UpdateNewsSubcategory(UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO);
        Task<ResponseModelDTO<IEnumerable<NewsSubcategory>>> DeleteNewsSubcategory(UpdateNewsSubcategoryDTO updateNewsSubcategoryDTO);
    }
}
