using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ReaderUserConfiguration : IEntityTypeConfiguration<ReaderUser>
    {
        public void Configure(EntityTypeBuilder<ReaderUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.CompleteName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(510);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(1020);
            builder.Property(u => u.Status).IsRequired();
            builder.HasMany(u => u.FavoritedNews).WithMany(n => n.FavoritedBy);
            builder.HasMany(u => u.ProfessionalInformations).WithOne(pi => pi.User).HasForeignKey(pi => pi.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.ProfessionalSkills).WithOne(ps => ps.User).HasForeignKey(ps => ps.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Formations).WithOne(f => f.User).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
