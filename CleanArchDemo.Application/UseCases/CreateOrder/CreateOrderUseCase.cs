using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;

namespace CleanArchDemo.Application.UseCases.CreateOrder;

public class CreateOrderUseCase
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;

    public CreateOrderUseCase(ICustomerRepository customerRepo, IProductRepository productRepo, IOrderRepository orderRepo)
    {
        _customerRepo = customerRepo;
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

    public CreateOrderResponse Handle(CreateOrderRequest request)
    {
        var customer = _customerRepo.GetById(request.CustomerId);
        var order = new Domain.Aggregates.Order(0, customer);

        foreach (var item in request.Items)
        {
            var product = _productRepo.GetById(item.ProductId);
            order.AddItem(product, new Quantity(item.Quantity));
        }

        _orderRepo.Save(order);

        var total = order.GetTotal();
        return new CreateOrderResponse(order.Id, total.Amount, total.Currency);
    }
}
