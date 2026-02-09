using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.Customers.CreateCustomer;

public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepo;

    public CreateCustomerUseCase(ICustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request,CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Name,
            Email = new EmailAddress()
            {
                Value = request.Email,
            },
            Address = new Address()
            {
               Street= request.Street,City= request.City,PostalCode= request.PostalCode
            }
        };

       await _customerRepo.AddAsync(customer, cancellationToken);

        return new CreateCustomerResponse(customer.Id);
    }
}
