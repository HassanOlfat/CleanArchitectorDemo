using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Application.UseCases.GetOrderById;

public class GetOrderByIdUseCase
{
    private readonly IOrderRepository _orderRepo;

    public GetOrderByIdUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public GetOrderByIdResponse Handle(GetOrderByIdRequest request)
    {
        var order = _orderRepo.GetById(request.OrderId);
        var total = order.GetTotal();

        return new GetOrderByIdResponse(order.Id, order.Customer.Name, total.Amount, total.Currency);
    }
}
