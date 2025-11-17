using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories.Abstractions;

namespace VizinhoDAgua.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
    }
}
