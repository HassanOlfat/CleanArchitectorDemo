using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.Enums;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Tests.Domain;


public class OrderTests
{
    [Fact]
    public void GetTotal_Should_Return_Zero_When_No_Items()
    {
        var order = new OrderItem() { Product = new(), Quantity = new() };

        var total = order.GetTotal();

        Assert.Equal(0, total.Amount);

    }

    [Fact]
    public void GetTotal_Should_Return_Correct_Total_For_Single_Item()
    {
        var product = new Product { Price = new Money(1000, eMoney.IRR) };
        Customer customer = new Customer() { Id = 1 };
        var item = new OrderItem() { Product = product, Quantity = new Quantity() { Value = 2 } };

        var order = new Order() { Customer = customer };
        order.Items.Add(item);

        var total = order.GetTotal();

        Assert.Equal(2000, total.Amount);
        Assert.Equal(eMoney.IRR, total.Currency);
    }

    [Fact]
    public void GetTotal_Should_Sum_Multiple_Items()
    {
        var product1 = new Product { Price = new Money(1000, eMoney.IRR) };
        var product2 = new Product { Price = new Money(500, eMoney.IRR) };
        Customer customer = new Customer() { Id = 1 };
        var order = new Order() { Customer= customer };
        order.Items.Add(new OrderItem() { Product = product1, Quantity = new() { Value = 2 } }); // 2000
        order.Items.Add(new OrderItem() { Product = product2, Quantity = new() { Value = 3 } }); // 1500

        var total = order.GetTotal();

        Assert.Equal(3500, total.Amount);
        Assert.Equal(eMoney.IRR, total.Currency);
    }
    [Fact]
    public void Conversion_Should_Be_Exact()
    {
        var usd = new Money(500, eMoney.USD);
        var quantity = new Quantity() { Value = 3 };

        var total = usd.Amount * quantity.Value * 14500;

        Assert.Equal(21750000, total);
    }

    [Fact]
    public void GetTotal_Should_Convert_USD_To_IRR_And_Sum()
    {
        var product1 = new Product { Price = new Money(1000, eMoney.IRR) };
        var product2 = new Product { Price = new Money(500, eMoney.USD) };

        Customer customer = new Customer() { Id = 1 };
        var order = new Order() { Customer = customer };
        order.Items.Add(new OrderItem() { Product = product1, Quantity = new Quantity() { Value = 2 } }); // 2000 IRR
        order.Items.Add(new OrderItem() { Product = product2, Quantity = new Quantity() { Value = 3 } }); // 21,750,000 IRR

        var total = order.GetTotal();

        Assert.Equal(21752000, total.Amount);
        Assert.Equal(eMoney.IRR, total.Currency);
    }



}

