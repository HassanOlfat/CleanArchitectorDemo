using CleanArchDemo.Application.UseCases.Customers.CreateCustomer;
using CleanArchDemo.Application.UseCases.Customers.GetCustomers;
using CleanArchDemo.Application.UseCases.Orders.CreateOrder;
using CleanArchDemo.Application.UseCases.Orders.GetOrderById;
using CleanArchDemo.Application.UseCases.Products.CreateProduct;
using CleanArchDemo.Application.UseCases.Products.GetProducts;
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