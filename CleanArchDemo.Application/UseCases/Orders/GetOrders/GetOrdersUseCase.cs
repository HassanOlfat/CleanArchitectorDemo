using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.Orders.GetOrders;

public class GetOrdersUseCase
{
    private readonly IOrderRepository _orderRepo;
    private readonly ICacheService _cache;

    public GetOrdersUseCase(IOrderRepository orderRepo, ICacheService cache)
    {
        _orderRepo = orderRepo;
        _cache = cache;
    }

    public async Task<GetOrdersResponse> HandleAsync(CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.Orders;

        var cached = await _cache.GetAsync<GetOrdersResponse>(cacheKey, cancellationToken);

        if (cached != null)
        {
            return cached;
        }


        var orders = await _orderRepo.GetTopRowsAsync(1000, cancellationToken);
        var dto = orders.Select(OrderDto.From).ToList();
        var response = new GetOrdersResponse(dto);

        await _cache.SetAsync(
            cacheKey,
            response,
            TimeSpan.FromMinutes(5),
            cancellationToken
        );

        return new GetOrdersResponse(dto);
    }
}
