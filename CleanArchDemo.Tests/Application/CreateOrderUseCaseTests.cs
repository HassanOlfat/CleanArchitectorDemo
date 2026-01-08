using CleanArchDemo.Application.UseCases.CreateOrder;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using CleanArchDemo.Infrastructure.Persistence;
using CleanArchDemo.Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;

namespace CleanArchDemo.Tests.Application;

public class CreateOrderUseCaseTests
{
    [Fact]
    public async Task Should_Create_Order_With_Valid_Customer_And_Products()
    {
        // Arrange
    var customerRepo = new CustomerRepository();
        var productRepo = new ProductRepository();
        var orderRepo = new OrderRepository();

        var customer = new Customer() 
        {
            Name = "Hassan",
            Email = new EmailAddress("hassan.olfat@outlook.com"),
            Address = new Address("Street", "City", "00000")
        }; 
      await  customerRepo.AddAsync(customer);

        var product = new Product { Id = 1, Name = "Oil", Price = new Money(1000, "IRR") };
        productRepo.Save(product);

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
        var response = useCase.Handle(request);

        // Assert
        Assert.Equal(2000, response.TotalAmount);
        Assert.Equal("IRR", response.Currency);
    }

}
