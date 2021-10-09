using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetItems();
        Task<ProductModel> GetItem(string id);
        Task CreateItem(ProductModel Item);
        Task<bool> UpdateItem(ProductModel Item);
        Task<bool> DeleteItem(string id);
    }
}
