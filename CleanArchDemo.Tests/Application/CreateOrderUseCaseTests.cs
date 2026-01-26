using CleanArchDemo.Application.UseCases.CreateOrder;
using CleanArchDemo.Domain.Entities;
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
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDb")
           
           .Options;
        var context = new AppDbContext(options);


        var customerRepo = new CustomerRepository(context);
        var productRepo = new ProductRepository(context);
        var orderRepo = new OrderRepository(context);

        var customer = new Customer()
        {
            Name = "Hassan",
            Email = new EmailAddress() { Value= "hassan.olfat@outlook.com" },
            Address = new Address()
            {
               Street= "Street",City= "City",PostalCode= "00000"
            }
        };
        await customerRepo.AddAsync(customer);

        var product = new Product { Id = 1, Name = "Oil", Price = new Money(1000, "IRR") };
        await productRepo.AddAsync(product);

        var request = new CreateOrderRequest
        {
            CustomerId = 1,
            Items = new List<OrderItemRequest>
        {
            new OrderItemRequest { ProductId = 1, Quantity = 2 }
        }
        };

        var useCase = new CreateOrderUseCase(customerRepo, productRepo, orderRepo);

        // Act
        var response =await useCase.Handle(request);

        // Assert
        Assert.Equal(2000, response.TotalAmount);
        Assert.Equal("IRR", response.Currency);
    }

}
