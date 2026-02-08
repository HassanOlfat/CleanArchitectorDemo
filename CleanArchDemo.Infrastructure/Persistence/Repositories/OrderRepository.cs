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



    public async Task<Order> GetByIdAsync(int id)
    {
        var val= await _context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Items)
                             .FirstOrDefaultAsync(o => o.Id == id);

        if (val is null) { throw new Exception("Order not found"); }

        return val;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Items)
                             .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
