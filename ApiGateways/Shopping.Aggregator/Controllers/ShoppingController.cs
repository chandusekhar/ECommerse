using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;

        public ShoppingController(IProductService productService, ICampaignService campaignService, IOrderService orderService)
        {
            _productService = productService ?? throw new ArgumentException(nameof(productService));
            _campaignService = campaignService ?? throw new ArgumentException(nameof(campaignService));
            _orderService = orderService ?? throw new ArgumentException(nameof(orderService));
        }
        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel order)
        {
            var product = await _productService.GetItem(order.ProductId);
            if(product.Stock >= order.Quantity)
            {
                var campaigns = await _campaignService.GetOffers();
                var campaign = campaigns.Where(x => x.ProductId == product.Id).FirstOrDefault();

                if (campaign != null)
                    product.Price -= campaign.PriceManipulationLimit;

                if (product.Price < 0)
                    product.Price = 1;

                order.TotalPrice = order.Quantity * product.Price;

                var orderResponse = await _orderService.CreateOrder(order);
                if (orderResponse)
                    return Ok();
            }
            return BadRequest();
        }
    }
}
