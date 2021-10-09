using Campaign.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Data
{
    public class OfferContext : IOfferContext
    {
        public OfferContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Offers = database.GetCollection<Offer>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            OfferContextSeed.SeedData(Offers);
        }

        public IMongoCollection<Offer> Offers { get; }
    }
}
