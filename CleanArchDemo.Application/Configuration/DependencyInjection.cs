using Microsoft.Extensions.DependencyInjection;
using CleanArchDemo.Application.UseCases.CreateCustomer;
using CleanArchDemo.Application.UseCases.GetProducts;
using CleanArchDemo.Application.UseCases.CreateOrder;
using CleanArchDemo.Application.UseCases.GetOrderById;

namespace CleanArchDemo.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register Use Cases
        services.AddScoped<CreateCustomerUseCase>();
        services.AddScoped<GetProductsUseCase>();
        services.AddScoped<CreateOrderUseCase>();
        services.AddScoped<GetOrderByIdUseCase>();

        return services;
    }
}