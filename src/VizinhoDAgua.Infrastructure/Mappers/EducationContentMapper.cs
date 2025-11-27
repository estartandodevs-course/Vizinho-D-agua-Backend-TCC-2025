using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class EducationContentMap : IEntityTypeConfiguration<EducationContentEntity>
    {
        public void Configure(EntityTypeBuilder<EducationContentEntity> builder)
        {
            builder.ToTable("EducationContent");

            builder.HasKey(content => content.Id);

            // Propriedades básicas
            builder.Property(content => content.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(content => content.FilePath)
                .HasMaxLength(1000);

            builder.Property(content => content.ContentType)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
