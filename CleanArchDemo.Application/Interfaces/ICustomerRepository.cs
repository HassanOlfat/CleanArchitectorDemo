using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
    }

}
