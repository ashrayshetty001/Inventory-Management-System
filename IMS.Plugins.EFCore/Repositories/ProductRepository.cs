using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.Plugins.EFCore;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore.Repositories
{
    // Use Inventory (core model) and IMSContext (EF bridge) to match the rest of the solution.
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext _context;

        public InventoryRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return await _context.Inventories.ToListAsync();

            return await _context.Inventories
                .Where(x => EF.Functions.Like(x.InventoryName, $"%{name}%"))
                .ToListAsync();
        }

        // Optional additional CRUD methods that operate on Inventory
        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventories.FirstOrDefaultAsync(x => x.InventoryId == id);
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
