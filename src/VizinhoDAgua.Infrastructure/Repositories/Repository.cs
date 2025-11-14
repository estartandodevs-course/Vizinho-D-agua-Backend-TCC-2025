using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, new()
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return;
            
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}