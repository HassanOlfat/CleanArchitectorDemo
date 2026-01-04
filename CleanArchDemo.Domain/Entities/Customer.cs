using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public EmailAddress Email { get; set; } = new EmailAddress("default@example.com");
    public Address Address { get; set; } = new Address("Street", "City", "00000");


}
