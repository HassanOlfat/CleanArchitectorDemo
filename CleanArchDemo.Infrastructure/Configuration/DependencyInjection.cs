using Microsoft.Extensions.DependencyInjection;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Infrastructure.InMemory;

namespace CleanArchDemo.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

        return services;
    }
}