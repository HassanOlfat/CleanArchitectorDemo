using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Application.UseCases.Orders.CreateOrder;

public record CreateOrderResponse(int OrderId, decimal TotalAmount, eMoney Currency);