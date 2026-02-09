using CleanArchDemo.Application.UseCases.Orders.CreateOrder;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.Enums;
using CleanArchDemo.Domain.ValueObjects;
using CleanArchDemo.Infrastructure.Persistence;
using CleanArchDemo.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchDemo.Tests.Application;

public class CreateOrderUseCaseTests
{
    [Fact]
    public async Task Should_Create_Order_With_Valid_Customer_And_Products()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        var cancellationToken = CancellationToken.None;

        var customerRepo = new CustomerRepository(context);
        var productRepo = new ProductRepository(context);
        var orderRepo = new OrderRepository(context);

        var customer = new Customer
        {
            Name = "Hassan",
            Email = new EmailAddress { Value = "hassan.olfat@outlook.com" },
            Address = new Address { Street = "Street", City = "City", PostalCode = "00000" }
        };
        await customerRepo.AddAsync(customer, cancellationToken);

        var product = new Product { Name = "Oil", Price = new Money(1000, eMoney.IRR) };
        await productRepo.AddAsync(product, cancellationToken);

        var request = new CreateOrderRequest
        {
            CustomerId = customer.Id,
            Items = new List<OrderItemRequest>
        {
            new OrderItemRequest { ProductId = product.Id, Quantity = 2 }
        }
        };

        var useCase = new CreateOrderUseCase(customerRepo, productRepo, orderRepo);

        var response = await useCase.Handle(request, cancellationToken);

        Assert.Equal(2000, response.TotalAmount);
        Assert.Equal(eMoney.IRR, response.Currency);
    }


}
