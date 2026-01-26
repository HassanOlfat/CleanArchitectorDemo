using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.Entities;
using CleanArchDemo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchDemo.Application.UseCases.CreateOrder
{
    public class CalculateOrderTotalUseCase
    {
        private readonly ICurrencyConverter _converter;
        private readonly IOrderRepository _orderRepo;

        public CalculateOrderTotalUseCase(ICurrencyConverter converter, IOrderRepository orderRepo)
        {
            _converter = converter;
            _orderRepo = orderRepo;
        }

        public async Task<Money> Handle(int orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            foreach (OrderItem item in order.Items)
            {
                item.Product.Price = _converter.Convert(item.Product.Price, "IRR");
            }

            return order.GetTotal();
        }
    }
}
