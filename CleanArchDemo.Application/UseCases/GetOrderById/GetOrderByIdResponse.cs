namespace CleanArchDemo.Application.UseCases.GetOrderById;

public record GetOrderByIdResponse(int OrderId, string CustomerName, decimal TotalAmount, string Currency);

