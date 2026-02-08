using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.UseCases.GetProducts;

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

    public async Task<GetCustomersResponse> HandleAsync()
    {

        var cacheKey = CacheKeys.Customers;

        var cached = await _cache.GetAsync<GetCustomersResponse>(cacheKey);

        if (cached != null)
        {
            return cached;
        }

        var customers = await _customerRepo.GetAll();
        var dto = customers.Select(CustomerDto.From).ToList();
        var response = new GetCustomersResponse(dto);

        await _cache.SetAsync(
            cacheKey,
            response,
            TimeSpan.FromMinutes(5)
        );
        return new GetCustomersResponse(dto);


    }

}
