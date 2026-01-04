using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.CreateProduct;

public class CreateProductRequest
{
    public string Name { get; set; }
    public MoneyDto Price { get; set; }
}
