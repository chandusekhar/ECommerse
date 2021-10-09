using Campaign.API.Data;
using Campaign.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.API.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IOfferContext _context;

        public OfferRepository(IOfferContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Offer>> GetOffers()
        {
            return await _context
                            .Offers
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Offer> GetOffer(string id)
        {
            return await _context
                           .Offers
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }
        public async Task CreateOffer(Offer offer)
        {
            await _context.Offers.InsertOneAsync(offer);
        }

        public async Task<bool> UpdateOffer(Offer offer)
        {
            var updateResult = await _context
                                        .Offers
                                        .ReplaceOneAsync(filter: g => g.Id == offer.Id, replacement: offer);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteOffer(string id)
        {
            FilterDefinition<Offer> filter = Builders<Offer>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Offers
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
