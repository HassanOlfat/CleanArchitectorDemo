using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public EmailAddress Email { get; set; } = new EmailAddress() { Value= "default@example.com" };
    public Address Address { get; set; } = new Address() { Street="Street",City= "City",PostalCode= "00000" };

    // Navigation property
    public List<Order> Orders { get; set; } = new();
}
