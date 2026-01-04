using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Application.UseCases.CreateProduct;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepo;

    public CreateProductUseCase(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public CreateProductResponse Handle(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
           Price=new Money(request.Price.Amount, request.Price.Currency)
        };

        _productRepo.Save(product);

        return new CreateProductResponse(product.Id);
    }
}
