using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.Enums;

namespace CleanArchDemo.Application.Dtos;


public record ProductDto(
    int Id,
    string? Name,
    decimal Price,
    eMoney? Currency
)
{
    public static ProductDto From(Product product)
        => new(
            product.Id,
            product.Name,
            product.Price.Amount,
            product.Price.Currency
        );
}
