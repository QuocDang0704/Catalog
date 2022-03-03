using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IRepositoryCatalog
    {
        public IEnumerable<Item> GetItems();
        public Item GetItem(string id);
        public bool CreateItem (Item item);
        public bool UpdateItem (Item item);
        public bool DeleteItem (string id);

    }
}