using Campaign.API.Entities;
using Campaign.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Campaign.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IOfferRepository _repository;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(IOfferRepository repository, ILogger<CampaignController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Offer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            var offers = await _repository.GetOffers();
            return Ok(offers);
        }

        [HttpGet("{id:length(24)}", Name = "GetOffer")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Offer>> GetOfferById(string id)
        {
            var offer = await _repository.GetOffer(id);
            if (offer == null)
            {
                _logger.LogError($"Offer with id: {id}, not found.");
                return NotFound();
            }
            return Ok(offer);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Offer>> CreateOffer([FromBody] Offer offer)
        {
            await _repository.CreateOffer(offer);

            return CreatedAtRoute("GetOffer", new { id = offer.Id }, offer);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOffer([FromBody] Offer offer)
        {
            return Ok(await _repository.UpdateOffer(offer));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteOffer")]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOfferById(string id)
        {
            return Ok(await _repository.DeleteOffer(id));
        }
    }
}
