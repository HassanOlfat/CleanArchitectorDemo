using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Application.Dtos;

public class MoneyDto
{
    public decimal Amount { get; set; }
    public eMoney Currency { get; set; }
}
