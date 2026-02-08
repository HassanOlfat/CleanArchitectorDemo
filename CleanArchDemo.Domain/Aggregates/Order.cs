using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.Enums;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Aggregates;

public class Order
{
    public int Id { get;  set; }
    public Customer Customer { get; set; }
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
    }

    public void AddItem(Product product, Quantity quantity)
    {
        _items.Add(new OrderItem() { Product = product, Quantity = quantity });
    }

    public Money GetTotal()
    {
        if (!_items.Any()) return new Money(0, eMoney.IRR);

        Money price = _items.First().Product.Price;
        var currency = GetCurrency(price);
        decimal total = _items.Sum(i => i.Product.Price.Amount * i.Quantity.Value);

        return new Money(total, currency);

        static eMoney GetCurrency(Money price)
        {
            if (price is null)
                throw new ArgumentNullException(nameof(price));
            return price.Currency;
        }
    }
}