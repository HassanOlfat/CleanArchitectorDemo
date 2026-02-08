using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.Products.CreateProduct;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepo;

    public CreateProductUseCase(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
           Price=new Money(request.Price.Amount, request.Price.Currency)
        };

       await _productRepo.AddAsync(product);

        return new CreateProductResponse(product.Id);
    }
}
