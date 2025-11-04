using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using VizinhoDAgua.Domain.Entidades;

namespace VizinhoDAgua.API.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var order = modelBuilder.Entity<OrderEntity>();

        order.ToTable("orders");
        order.HasKey(o => o.Id);

        order.Property(o => o.Id)
            .HasColumnName("id")
            .HasMaxLength(64)
            .IsRequired();

        order.Property(o => o.CustomerId)
            .HasColumnName("customer_id")
            .HasMaxLength(128)
            .IsRequired();

        order.Property(o => o.TotalAmount)
            .HasColumnName("total_amount")
            .HasPrecision(18, 2);

        // Store Items as JSON
        var jsonConverter = new ValueConverter<List<string>, string>(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>()
        );

        order.Property(o => o.Items)
            .HasColumnName("items_json")
            .HasConversion(jsonConverter)
            .HasColumnType("json");

        order.Property(o => o.OrderDate)
            .HasColumnName("order_date");

        order.Property(o => o.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        order.Property(o => o.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValue(null);
    }
}


