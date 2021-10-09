using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Entities
{
    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
