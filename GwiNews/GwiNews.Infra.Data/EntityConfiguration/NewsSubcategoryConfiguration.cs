using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsSubcategoryConfiguration :IEntityTypeConfiguration<NewsSubcategory>
    {
        public void Configure(EntityTypeBuilder<NewsSubcategory> builder)
        {
            builder.HasKey(ns => ns.Id);
            builder.Property(ns => ns.Name).IsRequired().HasMaxLength(55);
            builder.Property(ns => ns.Status).IsRequired();
            builder.HasMany(ns => ns.News).WithMany(n => n.Subcategories);
        }
    }
}
