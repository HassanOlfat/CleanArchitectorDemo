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


        public Customer? GetById(int id)
        {
            return _context.Customers
                           .Include(c => c.Orders) 
                           .FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers
                           .Include(c => c.Orders)
                           .ToList();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers
                                 .Include(c => c.Orders)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers
                                 .Include(c => c.Orders)
                                 .ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }

