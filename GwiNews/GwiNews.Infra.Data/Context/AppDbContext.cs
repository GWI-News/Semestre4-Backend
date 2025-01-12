using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GwiNews.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<UserWithNews> UsersWithNews { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsSubcategory> NewsSubcategories { get; set; }
        public DbSet<ReaderUser> ReaderUsers { get; set; }
        public DbSet<ProfessionalInformation> ProfessionalInformations { get; set; }
        public DbSet<ProfessionalSkill> ProfessionalSkills { get; set; }
        public DbSet<Formation> Formations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserWithNewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NewsSubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalInformationConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalSkillConfiguration());
            modelBuilder.ApplyConfiguration(new FormationConfiguration());
        }
    }
}
