using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Tests.Domain
{
    using CleanArchDemo.Domain.Entities;
    using CleanArchDemo.Domain.ValueObjects;
    using System.Collections.Generic;
    using Xunit;

    public class OrderTests
    {
        [Fact]
        public void GetTotal_Should_Return_Zero_When_No_Items()
        {
            var order = new Order(); 

            var total = order.GetTotal();

            Assert.Equal(0, total.Amount);
            Assert.Equal("USD", total.Currency);
        }

        [Fact]
        public void GetTotal_Should_Return_Correct_Total_For_Single_Item()
        {
            var product = new Product { Price = new Money(1000, "IRR") };
            var item = new OrderItem(product, new Quantity(2));

            var order = new Order();
            order.Items.Add(item);

            var total = order.GetTotal();

            Assert.Equal(2000, total.Amount);
            Assert.Equal("IRR", total.Currency);
        }

        [Fact]
        public void GetTotal_Should_Sum_Multiple_Items()
        {
            var product1 = new Product { Price = new Money(1000, "IRR") };
            var product2 = new Product { Price = new Money(500, "IRR") };

            var order = new Order();
            order.Items.Add(new OrderItem(product1, new Quantity(2))); // 2000
            order.Items.Add(new OrderItem(product2, new Quantity(3))); // 1500

            var total = order.GetTotal();

            Assert.Equal(3500, total.Amount);
            Assert.Equal("IRR", total.Currency);
        }
        [Fact]
        public void Conversion_Should_Be_Exact()
        {
            var usd = new Money(500, "USD");
            var quantity = new Quantity(3);

            var total = usd.Amount * quantity.Value * 14500;

            Assert.Equal(21750000, total);
        }

        [Fact]
        public void GetTotal_Should_Convert_USD_To_IRR_And_Sum()
        {
            var product1 = new Product { Price = new Money(1000, "IRR") };
            var product2 = new Product { Price = new Money(500, "USD") };

            var order = new Order();
            order.Items.Add(new OrderItem(product1, new Quantity(2))); // 2000 IRR
            order.Items.Add(new OrderItem(product2, new Quantity(3))); // 21,750,000 IRR

            var total = order.GetTotal();

            Assert.Equal(21752000, total.Amount); 
            Assert.Equal("IRR", total.Currency);
        }



    }
}
