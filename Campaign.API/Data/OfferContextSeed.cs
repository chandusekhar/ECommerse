using Campaign.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Data
{
    public class OfferContextSeed
    {
        public static void SeedData(IMongoCollection<Offer> offerollection)
        {
            bool existProduct = offerollection.Find(p => true).Any();
            if (!existProduct)
            {
                offerollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Offer> GetPreconfiguredProducts()
        {
            return new List<Offer>()
            {
                new Offer()
                {
                    Id = "302d2149e773f2a3990b47f5",
                    Duration = 10,
                    ProductId = "602d2149e773f2a3990b47f5",
                     Name = "Offer1",
                      PriceManipulationLimit = 50,
                       TargetSalesCount =200
                },
                new Offer()
                {
                     Id = "867d2149e773f2a3990b47f5",
                      TargetSalesCount = 100,
                       PriceManipulationLimit = 200,
                        Name = "Offer2",
                         Duration = 40,
                    ProductId = "604d2149e773f2a3990b47f5",
                },
            };
        }
    }
}
