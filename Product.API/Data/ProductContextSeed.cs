using MongoDB.Driver;
using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Item> itemCollection)
        {
            bool existProduct = itemCollection.Find(p => true).Any();
            if (!existProduct)
            {
                itemCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Item> GetPreconfiguredProducts()
        {
            return new List<Item>()
            {
                new Item()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Stock = 200,
                    Price = 950.00M,
                },
                new Item()
                {
                    Id = "604d2149e773f2a3990b47f5",
                    Stock = 300,
                    Price = 150.00M,
                },
            };
        }
    }
}
