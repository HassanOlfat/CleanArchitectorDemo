namespace CleanArchDemo.Application.UseCases.CreateOrder;

public record CreateOrderRequest(int CustomerId, List<(int ProductId, int Quantity)> Items);
