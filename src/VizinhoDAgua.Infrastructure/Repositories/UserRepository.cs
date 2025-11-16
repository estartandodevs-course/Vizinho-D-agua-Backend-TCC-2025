using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Database;

namespace VizinhoDAgua.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(u => u.Communities)
                .Include(u => u.Posts)
                .Include(u => u.Reports)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}