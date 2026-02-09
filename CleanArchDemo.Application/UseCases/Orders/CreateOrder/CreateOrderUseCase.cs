using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Aggregates;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.Orders.CreateOrder;

public class CreateOrderUseCase
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;

    public CreateOrderUseCase(
        ICustomerRepository customerRepo,
        IProductRepository productRepo,
        IOrderRepository orderRepo)
    {
        _customerRepo = customerRepo;
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

    public async Task<CreateOrderResponse> Handle(
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepo.GetByIdAsync(request.CustomerId, cancellationToken);

        var productIds = request.Items
            .Select(i => i.ProductId)
            .Distinct()
            .ToList();

        var products = await _productRepo.GetByIdsAsync(productIds, cancellationToken);
        var productsById = products.ToDictionary(p => p.Id);

        var orderAggregate = new Domain.Aggregates.Order(0, customer);

        foreach (var item in request.Items)
        {
            if (!productsById.TryGetValue(item.ProductId, out var product))
                throw new Exception($"Product with id {item.ProductId} not found");

            orderAggregate.AddItem(
                product,
                new Quantity { Value = item.Quantity });
        }

        var orderEntity = new Domain.Entities.Order
        {
            Id = orderAggregate.Id,
            Customer = orderAggregate.Customer,
            Items = orderAggregate.Items
                .Select(i => new OrderItem
                {
                    Product = i.Product,
                    Quantity = i.Quantity
                })
                .ToList()
        };

        await _orderRepo.AddAsync(orderEntity, cancellationToken);

        var total = orderAggregate.GetTotal();

        return new CreateOrderResponse(
            orderAggregate.Id,
            total.Amount,
            total.Currency);
    }
}



