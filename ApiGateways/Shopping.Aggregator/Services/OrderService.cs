using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> CreateOrder(OrderModel order)
        {
            var response = await _client.PostAsJson($"/api/v1/Order/CreateOrder", order);
            return response.IsSuccessStatusCode;
        }
    }
}
