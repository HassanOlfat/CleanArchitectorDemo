using CleanArchDemo.Domain.Aggregates;

namespace CleanArchDemo.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);

    void Save(Order order);
    Order GetById(int id);
}