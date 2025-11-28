using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class AlertMapper : IEntityTypeConfiguration<AlertEntity>
    {
        public void Configure(EntityTypeBuilder<AlertEntity> builder)
        {
            builder.ToTable("Alerts");

            builder.HasKey(alert => alert.Id);

            // Propriedades básicas
            builder.Property(alert => alert.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(alert => alert.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(alert => alert.Status)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(alert => alert.PostalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(alert => alert.StateCode)
                .HasMaxLength(2);

            builder.Property(alert => alert.City)
                .HasMaxLength(150);

            builder.Property(alert => alert.Road)
                .HasMaxLength(150);

            builder.Property(alert => alert.Neighborhood)
                .HasMaxLength(150);

            // Relacionamento: Alerta → Denuncia (1:N)
            builder.HasMany(alert => alert.Reports)
                .WithOne(report => report.Alert)
                .HasForeignKey(report => report.AlertId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
