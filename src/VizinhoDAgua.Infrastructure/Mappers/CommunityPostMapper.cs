using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Infrastructure.Mappers
{
    public class CommunityPostMapper : IEntityTypeConfiguration<CommunityPostEntity>
    {
        public void Configure(EntityTypeBuilder<CommunityPostEntity> builder)
        {
            builder.ToTable("CommunityPosts");

            builder.HasKey(post => post.Id);

            // Propriedades básicas
            builder.Property(post => post.Content)
                .HasMaxLength(3000)
                .IsRequired();

            builder.Property(post => post.Images)
                .HasColumnType("json");

            // Relacionamento: Usuário → Posts da Comunidade (1:N)
            builder.HasOne(post => post.Author)
                .WithMany(user => user.Posts)
                .HasForeignKey(post => post.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento: Comunidade → Posts (1:N)
            builder.HasOne(post => post.Community)
                .WithMany(community => community.Posts)
                .HasForeignKey(post => post.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
