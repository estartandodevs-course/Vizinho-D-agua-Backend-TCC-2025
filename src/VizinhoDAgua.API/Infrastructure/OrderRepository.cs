using Microsoft.EntityFrameworkCore;
using VizinhoDAgua.Domain.Entidades;
using VizinhoDAgua.Domain.Repository;

namespace VizinhoDAgua.API.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<OrderEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<OrderEntity?> GetById(string id, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task Add(OrderEntity order, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(order.Id))
        {
            order.Id = Guid.NewGuid().ToString("N");
        }

        await _dbContext.Orders.AddAsync(order, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(OrderEntity order, CancellationToken cancellationToken)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(string id, CancellationToken cancellationToken)
    {
        var existing = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        if (existing is null)
        {
            return;
        }
        _dbContext.Orders.Remove(existing);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> GetTotalCount(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.CountAsync(cancellationToken);
    }

    public async Task<decimal> GetTotalRevenue(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.SumAsync(o => o.TotalAmount, cancellationToken);
    }
}


