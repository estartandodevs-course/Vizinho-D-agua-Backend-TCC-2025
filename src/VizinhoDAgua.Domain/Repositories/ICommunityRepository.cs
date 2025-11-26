using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Entities.Abstractions;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Domain.Repositories
{
    public interface ICommunityRepository : IRepository<CommunityEntity>
    {
        Task AddFollowerAsync(Guid communityId, Guid userId);
        Task RemoveFollowerAsync(Guid communityId, Guid userId);
        Task<int> GetFollowesCount(Guid id);
    }
}