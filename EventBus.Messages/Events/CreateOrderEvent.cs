using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Messages.Events
{
    public class CreateOrderEvent : IntegrationBaseEvent
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
