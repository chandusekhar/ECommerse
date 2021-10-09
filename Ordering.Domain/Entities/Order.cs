using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities
{
    public class Order : EntityBase
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
