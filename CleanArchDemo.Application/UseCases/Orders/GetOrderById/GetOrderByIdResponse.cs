using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Application.UseCases.Orders.GetOrderById;

public record GetOrderByIdResponse(int OrderId, string CustomerName, decimal TotalAmount, eMoney Currency);

