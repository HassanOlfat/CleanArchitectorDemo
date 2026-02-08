using CleanArchDemo.Domain.Enums;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public required Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();


    public Money GetTotal()
    {
        if (!Items.Any()) return new Money(0, eMoney.IRR);

        decimal total = 0;

        foreach (var item in Items)
        {
            var price = item.Product.Price;

            if (price.Currency == eMoney.USD)
            {
                total += price.Amount * item.Quantity.Value * 14500;

            }
            else if (price.Currency == eMoney.IRR)
            {
                total += price.Amount * item.Quantity.Value;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported currency: {price.Currency}");
            }
        }

        return new Money(total, eMoney.IRR);
    }
}
