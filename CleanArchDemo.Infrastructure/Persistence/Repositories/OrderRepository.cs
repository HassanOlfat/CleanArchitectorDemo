using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Order>> GetTopRowsAsync(int rowCount, CancellationToken cancellationToken)
    {
        var val = _context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Items)  
                             .ThenInclude(o=>o.Product)
                             .Take(rowCount)
                             .AsNoTracking();
        return await val.ToListAsync(cancellationToken);
    }
    public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var val= await _context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Items)
                             .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (val is null) { throw new Exception("Order not found"); }

        return val;
    }

    public async Task<List<Order>> GetAllAsync( CancellationToken cancellationToken)
    {
        return await _context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Items)
                             .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
