using Microsoft.AspNetCore.Mvc;
using CleanArchDemo.Application.UseCases.CreateCustomer;

namespace CleanArchDemo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CreateCustomerUseCase _createCustomer;

    public CustomerController(CreateCustomerUseCase createCustomer)
    {
        _createCustomer = createCustomer;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCustomerRequest request)
    {
        var response = _createCustomer.Handle(request);
        return Ok(response);
    }
}