using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.Customers.GetCustomers;

public class GetCustomersUseCase
{
    private readonly ICustomerRepository _customerRepo;
    private readonly ICacheService _cache;

    public GetCustomersUseCase(ICustomerRepository customerRepo, ICacheService cache)
    {
        _customerRepo = customerRepo;
        _cache = cache;

    }

    public async Task<GetCustomersResponse> HandleAsync(CancellationToken cancellationToken)
    {

        var cacheKey = CacheKeys.Customers;

        var cached = await _cache.GetAsync<GetCustomersResponse>(cacheKey, cancellationToken);

        if (cached != null)
        {
            return cached;
        }

        var customers = await _customerRepo.GetAll(cancellationToken);
        var dto = customers.Select(CustomerDto.From).ToList();
        var response = new GetCustomersResponse(dto);

        await _cache.SetAsync(
            cacheKey,
            response,
            TimeSpan.FromMinutes(5),
            cancellationToken
        );
        return new GetCustomersResponse(dto);


    }

}
