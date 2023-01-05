using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<InventoryItem>> GetByNameAndOrTypeAsync(string? name, string? type)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(type)) 
            {
                InventoryItem.InventoryItemType itemType;
                switch (type.ToLower())
                {
                    case "1":
                    case "recipe":
                    case "receita":
                        itemType = InventoryItem.InventoryItemType.Recipe;
                        break;
                    case "2":
                    case "resale":
                    case "revenda":
                        itemType = InventoryItem.InventoryItemType.Resale;
                        break;
                    default:
                        itemType = InventoryItem.InventoryItemType.Recipe;
                        break;
                }
                return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                  .Where(i => i.Eatable!.Name.Contains(name) && i.Type == itemType)
                                                  .ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                  .Where(i => i.Eatable!.Name.Contains(name))
                                                                  .ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(type))
            {
                InventoryItem.InventoryItemType itemType;
                switch (type.ToLower())
                {
                    case "1":
                    case "recipe":
                    case "receita":
                        itemType = InventoryItem.InventoryItemType.Recipe;
                        break;
                    case "2":
                    case "resale":
                    case "revenda":
                        itemType = InventoryItem.InventoryItemType.Resale;
                        break;
                    default:
                        itemType = InventoryItem.InventoryItemType.Recipe;
                        break;
                }
                return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                  .Where(i => i.Type == itemType)
                                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                  .ToListAsync();
            }
        }

        public async Task<InventoryItem?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.InventoryItems!.Include(i => i.Eatable)
                                                                     .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InventoryItem> CreateAsync(InventoryItem inventoryItem)
        {
            _applicationDbContext.Add(inventoryItem);
            await _applicationDbContext.SaveChangesAsync();
            return inventoryItem;
        }

        public async Task<InventoryItem> UpdateAsync(InventoryItem inventoryItem)
        {
            _applicationDbContext.Update(inventoryItem);
            await _applicationDbContext.SaveChangesAsync();
            return inventoryItem;
        }

        public async Task<InventoryItem> RemoveAsync(InventoryItem inventoryItem)
        {
            _applicationDbContext.Remove(inventoryItem);
            await _applicationDbContext.SaveChangesAsync();
            return inventoryItem;
        }

    }
}
