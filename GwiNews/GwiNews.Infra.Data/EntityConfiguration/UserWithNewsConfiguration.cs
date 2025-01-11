using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class UserWithNewsConfiguration : IEntityTypeConfiguration<UserWithNews>
    {
        public void Configure(EntityTypeBuilder<UserWithNews> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.CompleteName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(510);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(1020);
            builder.Property(u => u.Status).IsRequired();
            builder.HasMany(u => u.AuthoredNews).WithOne(n => n.Author).HasForeignKey(n => n.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.EditedNews).WithOne(n => n.Editor).HasForeignKey(n => n.EditorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
