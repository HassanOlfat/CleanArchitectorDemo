using CleanArchDemo.Application.Interfaces;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.Orders.GetOrderById;

public class GetOrderByIdUseCase
{
    private readonly IOrderRepository _orderRepo;

    public GetOrderByIdUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request)
    {
        var order =await _orderRepo.GetByIdAsync(request.OrderId);
        var total = order.GetTotal();

        return new GetOrderByIdResponse(order.Id, order.Customer.Name, total.Amount, total.Currency);
    }
}
