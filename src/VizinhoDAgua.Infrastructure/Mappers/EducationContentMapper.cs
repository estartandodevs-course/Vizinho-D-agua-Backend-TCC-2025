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

            builder.HasKey(ec => ec.Id);

            builder.Property(ec => ec.Title)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(ec => ec.FilePath)
                .HasColumnType("text")
                .HasMaxLength(1000);


            builder.Property(ec => ec.ContentType)
                .HasConversion<string>()
                .IsRequired();

            // Relacionamentos
            builder.HasOne(ec => ec.Author)
                .WithMany(u => u.EducationContents)
                .HasForeignKey(ec => ec.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}