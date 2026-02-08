using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Orders.CreateOrder;


public class OrderItemRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
