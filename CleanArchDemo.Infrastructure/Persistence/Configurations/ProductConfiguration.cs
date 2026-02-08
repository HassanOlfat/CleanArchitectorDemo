using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Price, c =>
            {
                c.Property(x => x.Amount)
                 .HasColumnType("decimal(18,2)")
                 .IsRequired();

                c.Property(x => x.Currency)
                 .HasConversion<string>()
                 .HasMaxLength(3)
                 .IsRequired();
            });



            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            //builder.Property(p => p.Price)
            //       .HasColumnType("decimal(18,2)");

            builder.ToTable("Products");

        }
    }

}
