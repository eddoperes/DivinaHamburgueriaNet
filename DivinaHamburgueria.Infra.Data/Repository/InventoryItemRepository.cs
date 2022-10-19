using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class InventoryItemRepository: IInventoryItemRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public InventoryItemRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                     .ToListAsync();
        }

        public async Task<InventoryItem?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                     .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InventoryItem> CreateAsync(InventoryItem itemDoEstoqueReceita)
        {
            _applicationDbContext.Add(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }

        public async Task<InventoryItem> UpdateAsync(InventoryItem itemDoEstoqueReceita)
        {
            _applicationDbContext.Update(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }

        public async Task<InventoryItem> RemoveAsync(InventoryItem itemDoEstoqueReceita)
        {
            _applicationDbContext.Remove(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }        

    }
}
