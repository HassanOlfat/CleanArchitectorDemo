using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Products.CreateProduct;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public required MoneyDto Price { get; set; }
}
