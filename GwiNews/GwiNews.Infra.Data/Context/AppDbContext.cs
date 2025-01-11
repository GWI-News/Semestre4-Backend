using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<UserWithNews> UsersWithNews { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserWithNewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
        }
    }
}
