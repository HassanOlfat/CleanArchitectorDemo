using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Services;

public static class DiscountService
{
    public static Money ApplyDiscount(Order order, decimal percentage)
    {
        var total = order.GetTotal();
        var discountAmount = total.Amount * (percentage / 100);
        return new Money(total.Amount - discountAmount, total.Currency);
    }
}