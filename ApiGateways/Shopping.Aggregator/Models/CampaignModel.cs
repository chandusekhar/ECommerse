using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class CampaignModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
