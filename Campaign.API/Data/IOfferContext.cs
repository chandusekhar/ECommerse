using Campaign.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Data
{
    public interface IOfferContext
    {
        IMongoCollection<Offer> Offers { get; }

    }
}
