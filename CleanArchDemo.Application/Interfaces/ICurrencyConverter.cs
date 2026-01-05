using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICurrencyConverter
    {
        Money Convert(Money money, string targetCurrency);
        Task<Money> ConvertAsync(Money money, string targetCurrency);


    }
}
