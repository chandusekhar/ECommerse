using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Items = database.GetCollection<Item>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ProductContextSeed.SeedData(Items);
        }

        public IMongoCollection<Item> Items { get; }
    }
}
