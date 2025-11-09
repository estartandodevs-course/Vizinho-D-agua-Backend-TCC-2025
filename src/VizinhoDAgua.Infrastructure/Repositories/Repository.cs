using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public abstract class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext _context = context;
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var dado = await _dbSet.ToListAsync();
            return dado;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var dado = await _dbSet.FindAsync(id);
            return dado;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            var dado = await _context.SaveChangesAsync();
            return dado;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}