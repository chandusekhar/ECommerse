using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.API.Entities;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IItemRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _repository.GetItems();
            return Ok(items);
        }

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> GetItemById(string id)
        {
            var item = await _repository.GetItem(id);
            if (item == null)
            {
                _logger.LogError($"Item with id: {id}, not found.");
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> CreateItem([FromBody] Item item)
        {
            await _repository.CreateItem(item);

            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            return Ok(await _repository.UpdateItem(item));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteItem")]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItemById(string id)
        {
            return Ok(await _repository.DeleteItem(id));
        }
    }
}
