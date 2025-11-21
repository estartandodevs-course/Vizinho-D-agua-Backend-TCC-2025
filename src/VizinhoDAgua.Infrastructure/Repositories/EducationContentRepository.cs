using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;
using VizinhoDAgua.Infrastructure.Repositories.Abstractions;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class EducationContentRepository(AppDbContext context) 
        : Repository<EducationContentEntity>(context), IEducationContentRepository
    {
    }
}
