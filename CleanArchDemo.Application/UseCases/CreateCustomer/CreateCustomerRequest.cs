namespace CleanArchDemo.Application.UseCases.CreateCustomer;

public record CreateCustomerRequest(string Name, string Email, string Street, string City, string PostalCode);
