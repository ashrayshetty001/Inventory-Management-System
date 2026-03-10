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
                new Inventory { InventoryId=1,InventoryName="Bike Seat",Quantity=5,Price=10 },
                new Inventory { InventoryId=2,InventoryName="Bike handle",Quantity=3,Price=5 },
                new Inventory { InventoryId=3,InventoryName="Bike peddle",Quantity=2,Price=1},
            };

            
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if(string.IsNullOrEmpty(name))
                return await Task.FromResult(_inventories);
            return await Task.FromResult(_inventories.Where(x=>x.InventoryName.Contains(name,StringComparison.OrdinalIgnoreCase)));
        }
    }
}
