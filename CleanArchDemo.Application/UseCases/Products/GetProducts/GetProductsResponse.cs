using CleanArchDemo.Application.Dtos;

namespace CleanArchDemo.Application.UseCases.Products.GetProducts;

public record GetProductsResponse(List<ProductDto> Products);


