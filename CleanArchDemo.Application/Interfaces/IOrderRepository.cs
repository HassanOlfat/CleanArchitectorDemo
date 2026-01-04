using CleanArchDemo.Domain.Aggregates;

namespace CleanArchDemo.Application.Interfaces;

public interface IOrderRepository
{
    void Save(Order order);
    Order GetById(int id);
}