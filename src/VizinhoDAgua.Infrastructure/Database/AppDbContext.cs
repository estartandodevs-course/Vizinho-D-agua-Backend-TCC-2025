using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<EducationContent> EducationContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many: User <-> Community
            modelBuilder.Entity<User>()
                .HasMany(u => u.Communities)
                .WithMany(c => c.Followers);

            // One-to-Many: Community -> CommunityPost
            modelBuilder.Entity<CommunityPost>()
                .HasOne(cp => cp.Community)
                .WithMany(c => c.Posts)
                .HasForeignKey(cp => cp.CommunityId);

            // One-to-Many: User -> CommunityPosts
            modelBuilder.Entity<CommunityPost>()
                .HasOne(cp => cp.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(cp => cp.AuthorId);
                
            // One-to-Many: User -> Reports
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.ReporterId);
        }
    }
}