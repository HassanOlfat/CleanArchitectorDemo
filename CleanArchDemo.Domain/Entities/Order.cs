using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();


    public Money GetTotal()
    {
        if (!Items.Any()) return new Money(0, "IRR");

        decimal total = 0;

        foreach (var item in Items)
        {
            var price = item.Product.Price;

            if (price.Currency == "USD")
            {
                total += price.Amount * item.Quantity.Value * 14500;

            }
            else if (price.Currency == "IRR")
            {
                total += price.Amount * item.Quantity.Value;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported currency: {price.Currency}");
            }
        }

        return new Money(total, "IRR");
    }
}
