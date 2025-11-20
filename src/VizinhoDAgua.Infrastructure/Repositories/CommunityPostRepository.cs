using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;
using VizinhoDAgua.Infrastructure.Repositories.Abstractions;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class CommunityPostRepository(AppDbContext context) : Repository<CommunityPostEntity>(context), ICommunityPostRepository
    {
    }
}
