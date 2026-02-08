using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(p => p.Email, c =>
            {
                c.Property(x => x.Value)
                 .HasConversion<string>()
                 .HasMaxLength(100)
                 .IsRequired();
            });

            builder.OwnsOne(p => p.Address, c =>
            {
              
                c.Property(x => x.Street)
                 .HasConversion<string>()
                 .HasMaxLength(50)
                 .IsRequired();

                c.Property(x => x.City)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

                c.Property(x => x.PostalCode)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();
            });



            builder.ToTable("Customers");

        }
    }

}
