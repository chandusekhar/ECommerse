using EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.EventBusConsumer
{
    public class CampaignConsumer : IConsumer<CampaignDiscountEvent>
    {
        private readonly ILogger<CampaignConsumer> _logger;
        private readonly IItemRepository _repository;

        public CampaignConsumer(IItemRepository repository, ILogger<CampaignConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        public async Task Consume(ConsumeContext<CampaignDiscountEvent> context)
        {
            _logger.LogInformation("OrderCreateEvent consumed successfully. Created ProductId:");
        }
    }
}
