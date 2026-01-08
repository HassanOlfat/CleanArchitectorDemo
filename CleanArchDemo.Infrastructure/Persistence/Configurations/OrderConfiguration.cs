using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Customer)
                   .WithMany(i=>i.Orders)               
                   .HasForeignKey("CustomerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Items)
                   .WithOne(i => i.Order)
                   .HasForeignKey("OrderItemsId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Orders");

        }
    }


}
