using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Ordering.Domain.Entities;
using Ordering.Application.Services;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrderCommand
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IProductService _productService;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger,IProductService productService)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));

        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            return newOrder.Id;
        }
    }
}
