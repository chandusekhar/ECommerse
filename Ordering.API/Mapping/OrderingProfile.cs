﻿using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrderCommand;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<Order, CreateOrderEvent>().ReverseMap();
            CreateMap<CheckoutOrderCommand, CreateOrderEvent>().ReverseMap();
        }
    }
}
