using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;

namespace Catalog.Service
{
    public class ServiceCatalog : IServiceCatalog
    {
        private readonly IRepositoryCatalog repository;
        public ServiceCatalog(IRepositoryCatalog repository){
            this.repository = repository;
        }
        public bool CreateItem(Item item)
        {
            if (repository.CreateItem(item))
            {
                return true;
            }
            return false;
        }

        public bool DeleteItem(string id)
        {
            if (repository.DeleteItem(id))
            {
                return true;
            }
            return false;
        }

        public Item GetItem(string id)
        {
            id = id.Trim();
            return repository.GetItem(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }

        public bool UpdateItem(string id, Item item)
        {
            if (repository.GetItem(id) is not null)
            {
                if (repository.UpdateItem(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}