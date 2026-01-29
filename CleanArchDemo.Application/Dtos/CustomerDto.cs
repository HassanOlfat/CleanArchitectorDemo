using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Dtos;

public record CustomerDto
(
     int Id ,
     string Name ,
     string? Email ,
     string? Street,
     string? City ,
     string? PostalCode
)
{
    public static CustomerDto From(Customer customer)
     => new(
         customer.Id,
         customer.Name,
         customer.Email.Value,
         customer.Address.Street,
         customer.Email.Value,
         customer.Address.PostalCode

     );
}
  
