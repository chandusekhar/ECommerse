using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Messages.Events
{
    public class CampaignDiscountEvent : IntegrationBaseEvent
    {
        public string ProductId { get; set; }
        public decimal PriceManipulationLimit { get; set; }
    }
}
