using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
    public async Task<List<Product>> GetTopRowsAsync(int rowCount, CancellationToken cancellationToken)
    {
       var val=   _context.Products.Take(rowCount);
        return await val.ToListAsync(cancellationToken);
    }
    public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var val= await _context.Products
                             .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (val is null) { throw new Exception("Product not found"); }
        return val;
    }

    public async Task<List<Product>> GetByIdsAsync(
    IEnumerable<int> ids,
    CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }


    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

 
}
