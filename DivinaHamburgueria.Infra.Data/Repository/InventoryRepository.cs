using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public InventoryRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _applicationDbContext.Inventories!.ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetByEatableAsync(int? eatableid)
        {
            if (eatableid != null && eatableid > 0)
            {
                return await _applicationDbContext.Inventories!
                                                  .Where(p => p.InventoryItem!.EatableId == eatableid)
                                                  .OrderBy(p => p.InventoryItem!.Eatable!.Name)
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.Inventories!
                                                  .OrderBy(p => p.InventoryItem!.Eatable!.Name)
                                                  .ToListAsync();
            }
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Inventories!.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Inventory?> GetByInventoryItemAsync(int inventoryItemId)
        {
            return await _applicationDbContext.Inventories!.FirstOrDefaultAsync(p => p.InventoryItemId == inventoryItemId);
        }

        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            _applicationDbContext.Add(inventory);
            await _applicationDbContext.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            _applicationDbContext.Update(inventory);
            await _applicationDbContext.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> RemoveAsync(Inventory inventory)
        {
            _applicationDbContext.Remove(inventory);
            await _applicationDbContext.SaveChangesAsync();
            return inventory;
        }

    }
}
