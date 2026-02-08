using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public required Product Product { get; set; }
    public required Quantity Quantity { get; set; }

    //public   Order Order { get; set; }

    public Money GetTotal() =>
        new Money(Product.Price.Amount * Quantity.Value, Product.Price.Currency);
}