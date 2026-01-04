using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.GetProducts;

public class GetProductsUseCase
{
    private readonly IProductRepository _productRepo;

    public GetProductsUseCase(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public List<ProductDto> Handle()
    {
        return _productRepo.GetAll()
     .Select(p => new ProductDto
     {
         Id = p.Id,
         Name = p.Name,
         Amount = p.Price.Amount,
         Currency = p.Price.Currency
     })
     .ToList();
    }
}
