using Microsoft.Extensions.DependencyInjection;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Infrastructure.Persistence.Repositories;

namespace CleanArchDemo.Infrastructure.Dependencies.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}