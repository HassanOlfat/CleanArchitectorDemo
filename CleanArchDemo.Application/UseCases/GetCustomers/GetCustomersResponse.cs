

namespace CleanArchDemo.Application.UseCases.GetCustomers;

public record GetCustomersResponse(List<(int Id, string Name, string Email, string Address)> Customers);


