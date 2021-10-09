using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly HttpClient _client;

        public CampaignService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task CreateOffer(CampaignModel Offer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOffer(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CampaignModel> GetOffer(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Campaign/{id}");
            return await response.ReadContentAs<CampaignModel>();
        }

        public async Task<IEnumerable<CampaignModel>> GetOffers()
        {
            var response = await _client.GetAsync("/api/v1/Campaign");
            return await response.ReadContentAs<List<CampaignModel>>();
        }

        public async Task<bool> UpdateOffer(CampaignModel Offer)
        {
            var response = await _client.PutAsJson($"/api/v1/Campaign",Offer);
            return response.IsSuccessStatusCode;
        }
    }
}
