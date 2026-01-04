using Microsoft.Extensions.DependencyInjection;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Infrastructure.InMemory;

namespace CleanArchDemo.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();
        services.AddScoped<IProductRepository, InMemoryProductRepository>();
        services.AddScoped<IOrderRepository, InMemoryOrderRepository>();

        return services;
    }
}