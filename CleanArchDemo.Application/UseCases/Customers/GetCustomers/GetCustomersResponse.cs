using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Customers.GetCustomers;

public record GetCustomersResponse(List<CustomerDto> Customers);


