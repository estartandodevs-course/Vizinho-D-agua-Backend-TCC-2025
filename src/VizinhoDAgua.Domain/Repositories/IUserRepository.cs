using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
    }
}
