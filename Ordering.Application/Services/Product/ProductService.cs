using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = 
                client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var response = await _client.GetAsync($"/Product/");
            return await response.ReadContentAs<List<ProductModel>>();
        }
        public async Task<ProductModel> GetProduct(string id)
        {
            var response = await _client.GetAsync($"/Product/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task UpdateProduct(ProductModel model)
        {
            
            var response = await _client.PutAsJson($"/Product", model);
            if (response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling api.");
        }

    }
}
