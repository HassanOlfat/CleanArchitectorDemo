using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class OrderItem
{
    public Product Product { get; }
    public Quantity Quantity { get; }

    public OrderItem(Product product, Quantity quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
    }

    public Money GetTotal() =>
        new Money(Product.Price.Amount * Quantity.Value, Product.Price.Currency);
}