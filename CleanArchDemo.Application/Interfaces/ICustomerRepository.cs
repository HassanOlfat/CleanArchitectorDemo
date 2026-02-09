using CleanArchDemo.Domain.Entities;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Customer customer, CancellationToken cancellationToken);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);

        Task<List<Customer>> GetAll(CancellationToken cancellationToken);


    }

}
