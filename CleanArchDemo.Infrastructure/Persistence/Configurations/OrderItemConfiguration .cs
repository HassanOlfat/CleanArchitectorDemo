using CleanArchDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchDemo.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.HasKey(oi => oi.Id);

            builder.HasOne(oi => oi.Product)
                   .WithMany() 
                   .HasForeignKey("ProductId");

            builder.HasOne<Order>() 
                   .WithMany(o => o.Items)
                   .HasForeignKey("OrderId");

            builder.OwnsOne(oi => oi.Quantity, q =>
            {
                q.Property(x => x.Value)
                 .HasColumnName("Quantity")
                 .IsRequired();
            });

            builder.ToTable("OrderItems");
        }
    }
}