using AutoMapper;
using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        {
            CreateMap<UserWithNews, CreateUserWithNewsDTO>().ReverseMap();
            CreateMap<UserWithNews, UpdateUserWithNewsDTO>().ReverseMap();
        }
    }
}
