using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(string id);
        Task UpdateProduct(ProductModel model);
    }
}
