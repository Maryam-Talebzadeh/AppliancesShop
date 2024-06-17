﻿using Base_Framework.Domain.General;
using Microsoft.Extensions.Configuration;
using SM.Domain.Core.OrderAgg.Data;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Entities;
using SM.Domain.Core.OrderAgg.Services;

namespace SM.Domain.Services.OrderAgg
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IConfiguration _configuration;

        public OrderService(IOrderRepository orderRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;

        }

        public async Task Cancel(long id, CancellationToken cancellationToken)
        {
            await _orderRepository.Cancel(id, cancellationToken);
            _orderRepository.Save();
        }

        public async Task<double> GetAmountBy(long id, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAmountBy(id, cancellationToken);
        }

        public async Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetItems(orderId, cancellationToken);
        }

        public async Task<string> PaymentSucceeded(long orderId, long refId, CancellationToken cancellationToken)
        {
            var symbol = _configuration.GetValue<string>("Symbol");
            var issueTrackingNo = CodeGenerator.Generate(symbol);
            //reduce order items from Inventory

            await _orderRepository.PaymentSucceeded(orderId, refId, issueTrackingNo, cancellationToken);
            _orderRepository.Save();
            return issueTrackingNo;
        }

        public async Task<long> PlaceOrder(CartDTO cart, CancellationToken cancellationToken)
        {
            var order = new OrderDTO()
            {
                AccountId = cart.AccountId,
                PaymentMethodId = cart.PaymentMethod,
                DiscountAmount = cart.DiscountAmount,
                PayAmount = cart.PayAmount
            };

            await _orderRepository.PlaceOrder(order, cancellationToken);

            foreach (var cartItem in cart.Items)
            {
                var orderItem = new OrderItemDTO()
                { 
                    ProductId = cartItem.Id,
                    Count = cartItem.Count,
                    UnitPrice = cartItem.UnitPrice,
                    DiscountRate = cartItem.DiscountRate
                };
               
             await _orderRepository.AddItem(orderItem, cancellationToken);
            }

            _orderRepository.Save();
            return order.Id;
        }

        public async Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken)
        {
            return await _orderRepository.Search(searchModel, cancellationToken);
        }
    }
}