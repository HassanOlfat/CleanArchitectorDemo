using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Application.Dtos;


public record OrderDto(
    int Id,
    int CustomerId,
    string? CustomerName,
    List<OrderItem> Items

)
{
    public static OrderDto From(Order product)
        => new(
            product.Id,
            product.Customer.Id,
            product.Customer.Name,
            product.Items
        );
}
