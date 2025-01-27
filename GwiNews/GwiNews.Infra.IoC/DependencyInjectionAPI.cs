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
            services.AddScoped<IProfessionalSkillService, ProfessionalSkillService>();
            services.AddScoped<IFormationService, FormationService>();
            services.AddScoped<IFirestoreToSqlServerDataStreamingService, FirestoreToSqlServerDataStreamingService>();

            services.AddAutoMapper(typeof(DtoToDomainMappingProfile));

            try
            {
                string firestoreKeyPath = Path.Combine(AppContext.BaseDirectory, "gwinews-firestore-api-key.json");
                string firestoreKeyContent = File.ReadAllText(firestoreKeyPath);
                Environment.SetEnvironmentVariable("GWINEWS_FIRESTORE_API_KEY", firestoreKeyContent);
            }
            catch (Exception ex)
            {
                string firestoreKeyContent = Environment.GetEnvironmentVariable("GWINEWS_FIRESTORE_API_KEY");
                if (string.IsNullOrEmpty(firestoreKeyContent))
                {
                    throw new InvalidOperationException("A variável de ambiente GWINEWS_FIRESTORE_API_KEY não está definida.");
                }
            }

            return services;
        }
    }
}
