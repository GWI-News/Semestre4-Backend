﻿using AutoMapper;
using GwiNews.Application.DTOs.UserWithNews;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Mappings
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile() 
        {
            CreateMap<CreateUserWithNewsDTO, UserWithNews>();
            CreateMap<UpdateUserWithNewsDTO, UserWithNews>();
        }
    }
}
