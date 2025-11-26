using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class ReportMap : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.ToTable("Reports");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                .HasColumnType("text")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.Attachments)
                .HasColumnType("json");

            builder.Property(r => r.Status)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.ReportType)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.WaterCompanyRelated)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .HasDefaultValue(new DateTime());

            // Desnormalização de Endereço
            builder.Property(r => r.StateCode)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(r => r.PostalCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.City)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(r => r.Neighborhood)
                .HasMaxLength(100);

            builder.Property(r => r.Road)
                .HasMaxLength(100);

            // Indices (otimiza a busca por esses campos)
            builder.HasIndex(r => r.StateCode);
            builder.HasIndex(r => r.City);

            // Relacionamentos
            builder.HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}