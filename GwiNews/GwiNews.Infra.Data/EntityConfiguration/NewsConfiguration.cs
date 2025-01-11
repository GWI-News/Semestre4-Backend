using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Status).IsRequired();
            builder.Property(n => n.NewsUrl).IsRequired().HasMaxLength(510);
            builder.Property(n => n.Title).IsRequired().HasMaxLength(75);
            builder.Property(n => n.Subtitle).IsRequired().HasMaxLength(255);
            builder.Property(n => n.NewsBody).IsRequired().HasMaxLength(65535);
            builder.Property(n => n.ImageUrl).IsRequired().HasMaxLength(510);
            builder.Property(n => n.PublishDate).IsRequired();
        }
    }
}
