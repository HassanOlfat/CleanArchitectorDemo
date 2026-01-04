using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Infrastructure.InMemory;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public Customer GetById(int id) =>
        _customers.FirstOrDefault(c => c.Id == id)
        ?? throw new Exception("Customer not found");

    public void Save(Customer customer)
    {
        if (customer.Id == 0)
            customer.Id = _customers.Count + 1;

        _customers.Add(customer);
    }
}