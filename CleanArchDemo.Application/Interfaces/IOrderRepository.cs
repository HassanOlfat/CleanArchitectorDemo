using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Order order, CancellationToken cancellationToken);
    Task UpdateAsync(Order order, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<List<Order>> GetTopRowsAsync(int rowCount, CancellationToken cancellationToken);

}