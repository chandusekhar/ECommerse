using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrdersVm
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
