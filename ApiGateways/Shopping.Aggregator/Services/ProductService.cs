using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task CreateItem(ProductModel Item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetItem(string id)
        {
            var item = await _client.GetAsync($"/api/v1/Product/{id}");
            return await item.ReadContentAs<ProductModel>();
        }

        public Task<IEnumerable<ProductModel>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(ProductModel Item)
        {
            var response = await _client.PutAsJson($"/api/v1/Product", Item);
            return response.IsSuccessStatusCode;
        }
    }
}
