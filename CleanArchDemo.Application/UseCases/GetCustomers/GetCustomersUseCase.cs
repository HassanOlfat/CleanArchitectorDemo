using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;


namespace CleanArchDemo.Application.UseCases.GetCustomers;

public class GetCustomersUseCase
{
    private readonly ICustomerRepository _customerRepo;

    public GetCustomersUseCase(ICustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public List<CustomerDto> Handle()
    {
        return _customerRepo.GetAll()
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email.Value,
                Street = c.Address.Street,
                City = c.Address.City,
                PostalCode = c.Address.PostalCode
            })
            .ToList();
    }

}
