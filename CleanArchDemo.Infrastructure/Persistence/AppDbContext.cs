using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CleanArchDemo.Infrastructure.Persistence
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
        .OwnsOne(c => c.Address);
            modelBuilder.Entity<Customer>()
        .OwnsOne(c => c.Email);

            modelBuilder.Entity<Product>()
        .OwnsOne(c => c.Price);

            modelBuilder.Entity<OrderItem>()
        .OwnsOne(c => c.Quantity);

            base.OnModelCreating(modelBuilder);

        }
    }

}


