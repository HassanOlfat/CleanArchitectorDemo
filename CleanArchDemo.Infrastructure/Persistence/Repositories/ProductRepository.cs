using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Application.Interfaces;

namespace CleanArchDemo.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();


    public Product GetById(int id) =>
        _products.FirstOrDefault(p => p.Id == id)
        ?? throw new Exception("Product not found");

    public List<Product> GetAll() => _products;

    public void Save(Product product)
    {
        if (product.Id == 0)
            product.Id = _products.Count + 1;

        _products.Add(product);
    }
}