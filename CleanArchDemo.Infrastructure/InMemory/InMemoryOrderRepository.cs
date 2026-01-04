using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Infrastructure.InMemory;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

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