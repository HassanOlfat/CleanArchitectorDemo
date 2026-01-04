using CleanArchDemo.Application.UseCases.CreateCustomer;
using CleanArchDemo.Application.UseCases.GetCustomers;
using CleanArchDemo.Application.UseCases.GetProducts;
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
    public IActionResult Create([FromBody] CreateCustomerRequest request)
    {
        var response = _createCustomer.Handle(request);
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _getCustomersResponse.Handle();
        return Ok(response);
    }
}