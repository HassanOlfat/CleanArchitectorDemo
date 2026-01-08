using Microsoft.Extensions.DependencyInjection;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Infrastructure.Persistence.Repositories;

namespace CleanArchDemo.Infrastructure.Dependencies.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IOrderRepository, OrderRepository>();

        return services;
    }
}