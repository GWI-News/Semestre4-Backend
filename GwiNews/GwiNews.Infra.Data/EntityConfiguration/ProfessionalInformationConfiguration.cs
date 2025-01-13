using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ProfessionalInformationConfiguration : IEntityTypeConfiguration<ProfessionalInformation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalInformation> builder)
        {
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.CompleteName).IsRequired().HasMaxLength(255);
            builder.Property(pi => pi.Email).IsRequired().HasMaxLength(255);
            builder.Property(pi => pi.CompleteAddress).IsRequired().HasMaxLength(510);
            builder.Property(pi => pi.Objective).IsRequired().HasMaxLength(255);
            builder.Property(pi => pi.ImgUrl).IsRequired().HasMaxLength(510);
            builder.Property(pi => pi.Status).IsRequired();
            builder.Property(pi => pi.WorkPlatformUrl).HasMaxLength(255);
        }
    }
}
