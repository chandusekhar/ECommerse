using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<CampaignModel>> GetOffers();
        Task<CampaignModel> GetOffer(string id);
        Task CreateOffer(CampaignModel Offer);
        Task<bool> UpdateOffer(CampaignModel Offer);
        Task<bool> DeleteOffer(string id);
    }
}
