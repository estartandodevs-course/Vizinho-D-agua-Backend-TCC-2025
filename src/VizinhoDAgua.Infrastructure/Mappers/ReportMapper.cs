using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class ReportMap : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Location)
                .WithOne()
                .HasForeignKey<ReportEntity>(r => r.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Description)
                .HasColumnType("text")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.Status)
                .HasConversion<string>();

            builder.Property(r => r.ReportType)
                .HasConversion<string>();

            builder.Property(r => r.CreatedAt)
                .HasDefaultValue(new DateTime());
        }
    }
}