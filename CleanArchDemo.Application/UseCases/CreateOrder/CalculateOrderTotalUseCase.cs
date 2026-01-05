using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Money Handle(int orderId)
        {
            var order = _orderRepo.GetById(orderId);

            foreach (var item in order.Items)
            {
                item.Product.Price = _converter.Convert(item.Product.Price, "IRR");
            }

            return order.GetTotal();
        }
    }
}
