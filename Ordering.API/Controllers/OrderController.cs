using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Extensions;
using Ordering.Application.Features.Orders.Commands.CheckoutOrderCommand;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Application.Services;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        private readonly IProductService _product;

        public OrderController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper, IProductService product)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _product = product ?? throw new ArgumentNullException(nameof(product));
        }


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
;
            CheckoutOrderCommand orderCommand = _mapper.Map<CheckoutOrderCommand>(order);
            var result = await _mediator.Send(orderCommand);

            var eventMessage = _mapper.Map<CreateOrderEvent>(order);
            await _publishEndpoint.Publish(eventMessage);
            return Accepted(result);
        }

        [HttpGet("{date}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrdersByDate(string date)
        {
            var query = new GetOrdersListQuery(Convert.ToDateTime(date));
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
