using Microsoft.AspNetCore.Mvc;
using CleanArchDemo.Application.UseCases.CreateOrder;
using CleanArchDemo.Application.UseCases.GetOrderById;

namespace CleanArchDemo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly CreateOrderUseCase _createOrder;
    private readonly GetOrderByIdUseCase _getOrder;

    public OrderController(CreateOrderUseCase createOrder, GetOrderByIdUseCase getOrder)
    {
        _createOrder = createOrder;
        _getOrder = getOrder;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrderRequest request)
    {
        var response = await _createOrder.Handle(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var response = _getOrder.Handle(new GetOrderByIdRequest(id));
        return Ok(response);
    }
}