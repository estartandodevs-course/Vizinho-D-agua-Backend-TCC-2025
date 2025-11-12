using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Location)
                .WithOne()
                .HasForeignKey<Report>(r => r.LocationId)
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