using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Desabilita o rastreamento automático em busca de alterações. Só afetam entidades carregadas via consultas (SELECT/GET)
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // Desabilita a detecção automática de mudanças para operações explícitas de atualização
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommunityEntity> Communities { get; set; }
        public DbSet<CommunityPostEntity> CommunityPosts { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<EducationContentEntity> EducationContents { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Busca classes que implementem IEntityTypeConfiguration em todo o projeto           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Retorna apenas as entries que implementam IAuditable (só as entidades que tem CreateAt e UpdatedAt)
            var entries = ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
                
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                    entry.Property(e => e.CreatedAt).IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}