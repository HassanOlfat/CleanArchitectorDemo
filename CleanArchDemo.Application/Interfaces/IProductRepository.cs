using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Interfaces;

public interface IProductRepository
{
    Product GetById(int id);
}