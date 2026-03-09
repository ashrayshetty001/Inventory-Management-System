using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System.Security.Cryptography.X509Certificates;

namespace IMS.Plugins.InMemory
{
    public class InventoyRepository : IInventoryRepository
    {
        public List<Inventory> _inventories;

        public InventoyRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { },
            };

            
        }
        public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            
        }
    }
}
