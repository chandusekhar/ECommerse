using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(string id);
        Task CreateItem(Item Item);
        Task<bool> UpdateItem(Item Item);
        Task<bool> DeleteItem(string id);
    }
}
