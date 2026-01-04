using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Aggregates;

public class Order
{
    public int Id { get; private set; }
    public Customer Customer { get; private set; }
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
    }

    public void AddItem(Product product, Quantity quantity)
    {
        var item = new OrderItem(product, quantity);
        _items.Add(item);
    }

    public Money GetTotal()
    {
        if (!_items.Any()) return new Money(0, "USD");

        string currency = _items.First().Product.Price.Currency;
        decimal total = _items.Sum(i => i.Product.Price.Amount * i.Quantity.Value);

        return new Money(total, currency);
    }
}