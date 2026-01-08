using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task<Order?> GetByIdAsync(int id) =>
        Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

    public Task<List<Order>> GetAllAsync() =>
        Task.FromResult(_orders.ToList());

    public Task AddAsync(Order order)
    {
        Save(order);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Order order)
    {
        var existing = _orders.FirstOrDefault(o => o.Id == order.Id);
        if (existing != null)
        {
            _orders.Remove(existing);
            _orders.Add(order);
        }
        return Task.CompletedTask;
    }


    public Task DeleteAsync(int id)
    {
        var existing = _orders.FirstOrDefault(o => o.Id == id);
        if (existing != null)
            _orders.Remove(existing);

        return Task.CompletedTask;
    }

    public Order GetById(int id) =>
        _orders.FirstOrDefault(o => o.Id == id)
        ?? throw new Exception("Order not found");

    public void Save(Order order)
    {
        if (order.Id == 0)
            order.Id = _orders.Count + 1;

        _orders.Add(order);
    }
}