using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrderCommand
{
    public class CheckoutOrderCommand : IRequest<int>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
