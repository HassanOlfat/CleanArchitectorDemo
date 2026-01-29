using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.GetProducts;

public class GetProductsUseCase
{
    private readonly IProductRepository _productRepo;
    private readonly ICacheService _cache;

    public GetProductsUseCase(IProductRepository productRepo, ICacheService cache)
    {
        _productRepo = productRepo;
        _cache = cache;
    }

    public async Task<GetProductsResponse> HandleAsync()
    {
        var cacheKey = CacheKeys.Products;

        var cached = await _cache.GetAsync<GetProductsResponse>(cacheKey);

        if (cached != null)
        {
            return cached;
        }


        var products = await _productRepo.GetTopRowsAsync(1000);
        var dto = products.Select(ProductDto.From).ToList();
        var response = new GetProductsResponse(dto);

        await _cache.SetAsync(
            cacheKey,
            response,
            TimeSpan.FromMinutes(5)
        );

        return new GetProductsResponse(dto);
    }
}
