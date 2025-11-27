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

            builder.HasKey(report => report.Id);

            // Propriedades básicas
            builder.Property(report => report.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(report => report.Attachments)
                .HasColumnType("json");

            builder.Property(report => report.Status)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(report => report.ReportType)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(report => report.WaterCompanyRelated)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            // Campos de endereço (desnormalizados)
            builder.Property(report => report.StateCode)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(report => report.City)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(report => report.PostalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(report => report.Neighborhood)
                .HasMaxLength(100);

            builder.Property(report => report.Road)
                .HasMaxLength(100);

            // Índices para otimizar consultas por filtros regionais
            builder.HasIndex(report => report.StateCode);
            builder.HasIndex(report => report.City);

            // Relacionamento: Usuário → Denuncias (1:N)
            builder.HasOne(report => report.Reporter)
                .WithMany(user => user.Reports)
                .HasForeignKey(report => report.ReporterId);

            // Relacionamento: Alerta → Denuncias (1:N)
            builder.HasOne(report => report.Alert)
                .WithMany(alert => alert.Reports)
                .HasForeignKey(report => report.AlertId);
        }
    }
}
