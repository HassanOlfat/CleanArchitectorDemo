using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public Quantity Quantity { get; set; }

    public Order Order { get; set; }
    //public OrderItem(Product product, Quantity quantity)
    //{
    //    Product = product ?? throw new ArgumentNullException(nameof(product));
    //    Quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
    //}

    public Money GetTotal() =>
        new Money(Product.Price.Amount * Quantity.Value, Product.Price.Currency);
}