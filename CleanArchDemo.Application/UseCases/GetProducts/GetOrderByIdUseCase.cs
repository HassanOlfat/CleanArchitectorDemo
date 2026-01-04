using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.GetProducts;

public class GetProductsUseCase
{
    private readonly IProductRepository _productRepo;

    public GetProductsUseCase(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public GetProductsResponse Handle()
    {
        var products = _productRepo.GetAll()
            .Select(p => (p.Id, p.Name, p.Price.Amount, p.Price.Currency))
            .ToList();

        return new GetProductsResponse(products);
    }
}
