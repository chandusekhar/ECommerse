using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class OrderModel
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
