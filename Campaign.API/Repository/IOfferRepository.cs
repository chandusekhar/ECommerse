using Campaign.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Repository
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> GetOffers();
        Task<Offer> GetOffer(string id);
        Task CreateOffer(Offer Offer);
        Task<bool> UpdateOffer(Offer Offer);
        Task<bool> DeleteOffer(string id);
    }
}
