using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.CreateOrder;


public class OrderItemRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
