namespace CleanArchDemo.Application.UseCases.CreateOrder;

public record CreateOrderResponse(int OrderId, decimal TotalAmount, string Currency);