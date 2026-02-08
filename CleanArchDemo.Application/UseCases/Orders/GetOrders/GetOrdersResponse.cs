using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Orders.GetOrders;

public record GetOrdersResponse(List<OrderDto> Orders);


