using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class CommunityMapper : IEntityTypeConfiguration<CommunityEntity>
    {
        public void Configure(EntityTypeBuilder<CommunityEntity> builder)
        {
            builder.ToTable("Communities");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.CoverImage);

            builder.HasOne(c => c.CreatedBy)
                .WithMany(u => u.Communities)
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(DeleteBehavior.SetNull);

            // Cria relaçãoque gera tabela CommunityUser (n para n)
            builder.HasMany(c => c.Followers)
                .WithMany(u => u.CommunitiesFollowed)
                .UsingEntity<Dictionary<string, object>>(
                    "CommunityFollowers", // nome da tabela
                    j => j.HasOne<UserEntity>()
                          .WithMany()
                          .HasForeignKey("UserId") // nome da coluna do usuário
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<CommunityEntity>()
                          .WithMany()
                          .HasForeignKey("CommunityId") // nome da coluna da comunidade
                          .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}