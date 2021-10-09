using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Product.API.EventBusConsumer
{
    public class CreateOrderConsumer : IConsumer<CreateOrderEvent>
    {
        private readonly ILogger<CreateOrderConsumer> _logger;
        private readonly IItemRepository _repository;

        public CreateOrderConsumer(IItemRepository repository,ILogger<CreateOrderConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        public async Task Consume(ConsumeContext<CreateOrderEvent> context)
        {
            Item item = await _repository.GetItem(context.Message.ProductId);
            item.Price = item.Price * Convert.ToDecimal(Math.Pow(1.01, context.Message.Quantity));
            item.Stock -= context.Message.Quantity;
            bool result = await _repository.UpdateItem(item);
            _logger.LogInformation("OrderCreateEvent consumed successfully. Created ProductId: {ProductId} Result:{Result}", item.Id, result);
        }
    }
}
