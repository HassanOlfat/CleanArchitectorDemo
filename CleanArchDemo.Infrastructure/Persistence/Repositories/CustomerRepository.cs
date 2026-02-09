using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo.Infrastructure.Persistence.Repositories;


    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Customers
                           .Include(c => c.Orders)
                           .ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var val= await _context.Customers
                                 .Include(c => c.Orders)
                                 .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if( val is null) {throw new Exception("Customer not found"); }
        return val;
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Customers
                                 .Include(c => c.Orders)
                                 .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

