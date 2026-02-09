using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.Products.GetProducts;

public class GetProductsUseCase
{
    private readonly IProductRepository _productRepo;
    private readonly ICacheService _cache;

    public GetProductsUseCase(IProductRepository productRepo, ICacheService cache)
    {
        _productRepo = productRepo;
        _cache = cache;
    }

    public async Task<GetProductsResponse> HandleAsync(CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.Products;

        var cached = await _cache.GetAsync<GetProductsResponse>(cacheKey, cancellationToken);

        if (cached != null)
        {
            return cached;
        }


        var products = await _productRepo.GetTopRowsAsync(1000, cancellationToken);
        var dto = products.Select(ProductDto.From).ToList();
        var response = new GetProductsResponse(dto);

        await _cache.SetAsync(
            cacheKey,
            response,
            TimeSpan.FromMinutes(5),
            cancellationToken
        );

        return new GetProductsResponse(dto);
    }
}
