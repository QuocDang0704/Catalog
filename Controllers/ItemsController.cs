using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;
using Catalog.Service;

namespace Catalog.Controllers
{
    [ApiController] // ~anotion-java // Todo: đánh dấu đây là bộ điều khiển API
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IServiceCatalog service;
        public ItemsController(IServiceCatalog service)
        {
            this.service = service;
        }

        [HttpGet] //! GET /items
        public IEnumerable<ItemDto> GetItems()
        {
            // var items = repository.GetItems().Select(item => item.AsDto());
            // return items;
            var items = service.GetItems().Select(item => item.AsDto());
            return items;
        }
        [HttpGet("{id}")] //! GET /items/{id}
        public ActionResult<ItemDto> GetItem(string id)
        {
            var item = service.GetItem(id);
            if (item is null)
            {
                return NoContent();
            }
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid()+"",
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreateDate = DateTimeOffset.UtcNow
            };
            if(service.CreateItem(item)){
                return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
            }
            return null;
            
        }

        [HttpPut("{id}")] //! GET /items/{id}
        public ActionResult UpdateItem(string id, UpdateItemDto itemDto)
        {
            Item item = new()
            {
                Id = id,
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            if (service.UpdateItem(id, item))
            {
                return NoContent();
            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(string id)
        {
            if (service.DeleteItem(id))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpGet("linq")]
        public IEnumerable<string> getScores()
        {
            int[] scores = { 90, 71, 82, 93, 75, 82 };
            IEnumerable<string> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select $"The score is {score}";
            return highScoresQuery;
        }
    }
}