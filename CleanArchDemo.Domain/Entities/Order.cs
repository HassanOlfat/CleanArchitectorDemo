using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    public Money GetTotal()
    {
        if (!Items.Any()) return new Money(0, "USD");

        string currency = Items.First().Product.Price.Currency;
        decimal total = Items.Sum(i => i.Product.Price.Amount * i.Quantity.Value);

        return new Money(total, currency);
    }
}
