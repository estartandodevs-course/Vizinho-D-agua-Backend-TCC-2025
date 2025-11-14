using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class CommunityRepository(AppDbContext context) : Repository<Community>(context), ICommunityRepository
    {
    }
}
