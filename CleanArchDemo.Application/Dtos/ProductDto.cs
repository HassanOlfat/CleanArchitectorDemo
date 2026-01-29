using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Dtos;


public record ProductDto(
    int Id,
    string? Name,
    decimal Price,
    string? Currency
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
