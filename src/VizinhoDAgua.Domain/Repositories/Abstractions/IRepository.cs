using VizinhoDAgua.Domain.Entities.Abstractions;

namespace VizinhoDAgua.Domain.Repositories.Abstractions
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
        Task<int> SaveChanges();
    }
}