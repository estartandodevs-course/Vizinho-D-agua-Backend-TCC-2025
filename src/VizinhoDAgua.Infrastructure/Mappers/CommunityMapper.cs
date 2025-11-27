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

            builder.HasKey(community => community.Id);

            // Propriedades básicas
            builder.Property(community => community.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(community => community.Description)
                .HasMaxLength(2000);

            builder.Property(community => community.CoverImage);

            // Relacionamento: Usuário → Comunidades Criadas (1:N)
            builder.HasOne(community => community.CreatedBy)
                .WithMany(user => user.Communities)
                .HasForeignKey(community => community.CreatedById); 
                
            // Relacionamento: Usuários/Seguidores ↔ Comunidades (N:N)
            builder.HasMany(community => community.Followers)
                .WithMany(user => user.CommunitiesFollowed)
                .UsingEntity<Dictionary<string, object>>(
                    "CommunityFollowers",
                    right => right.HasOne<UserEntity>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left.HasOne<CommunityEntity>()
                        .WithMany()
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join => join.HasKey("UserId", "CommunityId")
                );

            // Relacionamento: Comunidade → Posts (1:N)
            builder.HasMany(community => community.Posts)
                .WithOne(post => post.Community)
                .HasForeignKey(post => post.CommunityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
