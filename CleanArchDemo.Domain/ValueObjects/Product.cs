using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Domain.ValueObjects;

public record Money(decimal Amount, eMoney Currency )
{
  

    public override string ToString() => $"{Amount} {Currency}";
}
