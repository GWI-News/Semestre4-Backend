using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(nc => nc.Id);
            builder.Property(nc => nc.Name).IsRequired().HasMaxLength(25);
            builder.HasMany(nc => nc.News).WithOne(n => n.Category).HasForeignKey(n => n.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(nc => nc.Subcategories).WithOne(ns => ns.Category).HasForeignKey(ns => ns.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
