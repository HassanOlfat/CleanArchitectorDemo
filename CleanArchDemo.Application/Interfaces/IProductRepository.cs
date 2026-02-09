using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
     Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids,CancellationToken cancellationToken);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);



    Task<List<Product>> GetTopRowsAsync(int rowCount, CancellationToken cancellationToken);

}