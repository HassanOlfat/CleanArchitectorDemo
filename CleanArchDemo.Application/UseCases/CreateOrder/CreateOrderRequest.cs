using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.CreateOrder;

 
public class CreateOrderRequest
{
    public int CustomerId { get; set; }
    public List<OrderItemRequest> Items { get; set; } = new();

}