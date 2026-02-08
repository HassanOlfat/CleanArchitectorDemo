using CleanArchDemo.Application.UseCases.Orders.CreateOrder;
using CleanArchDemo.Application.UseCases.Orders.GetOrderById;
using CleanArchDemo.Application.UseCases.Orders.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly CreateOrderUseCase _createOrder;
    private readonly GetOrderByIdUseCase _getOrderById;
    private readonly GetOrdersUseCase _getOrder;
    public OrderController(CreateOrderUseCase createOrder, GetOrderByIdUseCase getOrderById, GetOrdersUseCase getOrder)
    {
        _createOrder = createOrder;
        _getOrderById = getOrderById;
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
        var response = _getOrderById.Handle(new GetOrderByIdRequest(id));
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getOrder.HandleAsync();
        return Ok(response);
    }
}