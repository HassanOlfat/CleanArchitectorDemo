namespace CleanArchDemo.Application.UseCases.Customers.CreateCustomer;

public record CreateCustomerRequest(string Name, string Email, string Street, string City, string PostalCode);
