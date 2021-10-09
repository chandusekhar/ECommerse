using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly IProductContext _context;

        public ItemRepository(IProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context
                            .Items
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Item> GetItem(string id)
        {
            return await _context
                           .Items
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }
        public async Task CreateItem(Item item)
        {
            await _context.Items.InsertOneAsync(item);
        }

        public async Task<bool> UpdateItem(Item item)
        {
            var updateResult = await _context
                                        .Items
                                        .ReplaceOneAsync(filter: g => g.Id == item.Id, replacement: item);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteItem(string id)
        {
            FilterDefinition<Item> filter = Builders<Item>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Items
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
