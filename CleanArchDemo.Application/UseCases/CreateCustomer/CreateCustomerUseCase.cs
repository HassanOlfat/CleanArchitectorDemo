using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.CreateCustomer;

public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepo;

    public CreateCustomerUseCase(ICustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            Name = request.Name,
            Email = new EmailAddress(request.Email),
            Address = new Address(request.Street, request.City, request.PostalCode)
        };

       await _customerRepo.AddAsync(customer);

        return new CreateCustomerResponse(customer.Id);
    }
}
