using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public DateTime CreatedDate { get; set; }

        public GetOrdersListQuery(DateTime createdDate)
        {
            CreatedDate = createdDate;
        }
    }
}
