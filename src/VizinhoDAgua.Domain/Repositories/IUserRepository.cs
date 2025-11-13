using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
