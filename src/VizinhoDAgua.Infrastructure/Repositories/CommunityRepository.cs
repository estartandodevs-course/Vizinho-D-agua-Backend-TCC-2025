using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;
using VizinhoDAgua.Infrastructure.Repositories.Abstractions;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class CommunityRepository(AppDbContext context) : Repository<CommunityEntity>(context), ICommunityRepository
    {
        public virtual async Task AddFollowerAsync(Guid communityId, Guid userId)
        {
            var community = new CommunityEntity { Id = communityId };
            var user = new UserEntity { Id = userId };

            // Coloca as entidades no tracking do EF Core sem buscar nada no banco.
            _context.Attach(community);
            _context.Attach(user);

            community.Followers.Add(user);

            await SaveChanges();
        }

        public async Task<int> GetFollowesCount(Guid id)
        {
            // Conta no banco quantos registros da tabela CommunityFollowers pertencem a essa comunidade
            return await _context
                .Set<Dictionary<string, object>>("CommunityFollowers")
                .CountAsync(cf =>
                    EF.Property<Guid>(cf, "CommunityId") == id);
        }

        public virtual async Task RemoveFollowerAsync(Guid communityId, Guid userId)
        {
            var community = new CommunityEntity { Id = communityId };
            var user = new UserEntity { Id = userId };

            // Coloca as entidades no tracking do EF Core sem buscar nada no banco.
            _context.Attach(community);
            _context.Attach(user);

            community.Followers.Add(user);

            await SaveChanges();
        }
    }
}
