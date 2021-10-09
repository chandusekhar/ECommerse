using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Product.API.Entities;

namespace Product.API.Data
{
    public interface IProductContext
    {
        IMongoCollection<Item> Items { get; }
    }
}
