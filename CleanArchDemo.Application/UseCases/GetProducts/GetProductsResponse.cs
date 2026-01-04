
namespace CleanArchDemo.Application.UseCases.GetProducts;

public record GetProductsResponse(List<(int Id, string Name, decimal Price, string Currency)> Products);


