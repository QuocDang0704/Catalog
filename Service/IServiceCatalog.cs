using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Service
{
    public interface IServiceCatalog
    {
        Item GetItem(string id);
        IEnumerable<Item> GetItems();
        bool CreateItem(Item item);
        bool UpdateItem(string id,Item item);
        bool DeleteItem(string id);
    }
}