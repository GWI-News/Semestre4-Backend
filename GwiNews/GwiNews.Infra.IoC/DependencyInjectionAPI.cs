using GwiNews.Application.Interfaces;
using GwiNews.Application.Mappings;
using GwiNews.Application.Services;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using GwiNews.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GwiNews.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserWithNewsRepository, UserWithNewsRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
            services.AddScoped<INewsSubcategoryRepository, NewsSubcategoryRepository>();
            services.AddScoped<IReaderUserRepository, ReaderUserRepository>();
            services.AddScoped<IProfessionalInformationRepository, ProfessionalInformationRepository>();
            services.AddScoped<IProfessionalSkillRepository, ProfessionalSkillRepository>();
            services.AddScoped<IFormationRepository, FormationRepository>();

            services.AddScoped<IUserWithNewsService, UserWithNewsService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsCategoryService, NewsCategoryService>();
            services.AddScoped<INewsSubcategoryService, NewsSubcategoryService>();
            services.AddScoped<IReaderUserService, ReaderUserService>();
            services.AddScoped<IProfessionalInformationService, ProfessionalInformationService>();

            services.AddAutoMapper(typeof(DtoToDomainMappingProfile));

            return services;
        }
    }
}
