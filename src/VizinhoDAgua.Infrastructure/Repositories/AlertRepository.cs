using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;
using VizinhoDAgua.Infrastructure.Repositories.Abstractions;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class AlertRepository : Repository<AlertEntity>, IAlertRepository
    {
        public AlertRepository(AppDbContext context) : base(context) { }
    }
}
