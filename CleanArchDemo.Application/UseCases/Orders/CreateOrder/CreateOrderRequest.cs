using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Orders.CreateOrder;

 
public class CreateOrderRequest
{
    public int CustomerId { get; set; }
    public List<OrderItemRequest> Items { get; set; } = new();

}