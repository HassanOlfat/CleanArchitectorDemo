using CleanArchDemo.Application.UseCases.CreateCustomer;
using CleanArchDemo.Application.UseCases.CreateOrder;
using CleanArchDemo.Application.UseCases.CreateProduct;
using CleanArchDemo.Application.UseCases.GetCustomers;
using CleanArchDemo.Application.UseCases.GetOrderById;
using CleanArchDemo.Application.UseCases.GetProducts;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchDemo.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register Use Cases

        services.AddScoped<GetProductsUseCase>();
        services.AddScoped<CreateProductUseCase>();

        services.AddScoped<CreateOrderUseCase>();
        services.AddScoped<GetOrderByIdUseCase>();
        
        services.AddScoped<CreateCustomerUseCase>();
        services.AddScoped<GetCustomersUseCase>();




        return services;
    }
}