using CleanArchDemo.Domain.ValueObjects;


namespace CleanArchDemo.Tests.Domain;

public class MoneyTests
{
    [Fact]
    public void Money_Should_Be_Equal_When_Amount_And_Currency_Are_Same()
    {
        // Arrange 
        var m1 = new Money(1000, "IRR");
        var m2 = new Money(1000, "IRR");

        // Act 
        var areEqual = m1 == m2;

        // Assert 
        Assert.True(areEqual);
    }
}
