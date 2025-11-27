using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            // Propriedades básicas
            builder.Property(user => user.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(100)
                .IsRequired();

            // Email único no sistema
            builder.HasIndex(user => user.Email).IsUnique();

            // Relacionamento: Usuário → Denuncias (1:N)
            builder.HasMany(user => user.Reports)
                .WithOne(report => report.Reporter)
                .HasForeignKey(report => report.ReporterId);

            // Relacionamento: Usuário → Posts da Comunidade (1:N)
            builder.HasMany(user => user.Posts)
                .WithOne(post => post.Author)
                .HasForeignKey(post => post.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: Usuário → Comunidades Criadas (1:N)
            builder.HasMany(user => user.Communities)
                .WithOne(community => community.CreatedBy)
                .HasForeignKey(community => community.CreatedById);

            // Relacionamento N:N (Usuários/Seguidores ↔ Comunidades)
            builder.HasMany(user => user.CommunitiesFollowed)
                .WithMany(community => community.Followers)
                .UsingEntity<Dictionary<string, object>>(
                    "CommunityFollowers",
                    right => right
                        .HasOne<CommunityEntity>()
                        .WithMany()
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left
                        .HasOne<UserEntity>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join => { join.HasKey("UserId", "CommunityId"); }
                );
        }
    }
}
