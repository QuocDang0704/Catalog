using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
namespace Catalog.Repositories
{
    public class InMemItemsRepositories : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Socola", Price = 2, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Dream", Price = 50, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "aluminum sword", Price = 60, CreateDate = DateTimeOffset.UtcNow }
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}