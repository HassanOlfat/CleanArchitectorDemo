using CleanArchDemo.Application.UseCases.Customers.CreateCustomer;
using CleanArchDemo.Application.UseCases.Customers.GetCustomers;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CreateCustomerUseCase _createCustomer;
    private readonly GetCustomersUseCase _getCustomersResponse;

    
    public CustomerController(CreateCustomerUseCase createCustomer , GetCustomersUseCase getCustomersResponse)
    {
        _createCustomer = createCustomer;
        _getCustomersResponse = getCustomersResponse;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
       
        var response = await _createCustomer.Handle(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
    {
        var response =await _getCustomersResponse.HandleAsync(cancellationToken);
        return Ok(response);
    }
}