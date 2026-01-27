using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Infrastructure.InMemory;
using CleanArchDemo.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDemo.Infrastructure.Dependencies.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddMemoryCache();
        services.AddScoped<ICacheService, MemoryCacheService>();
        return services;
    }
}