using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IInventoryItemRepository
    {

        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<IEnumerable<InventoryItem>> GetByNameAndOrTypeAsync(string? name, string? type);
        Task<InventoryItem?> GetByIdAsync(int id);
        Task<InventoryItem> CreateAsync(InventoryItem inventoryItem);
        Task<InventoryItem> UpdateAsync(InventoryItem inventoryItem);
        Task<InventoryItem> RemoveAsync(InventoryItem inventoryItem);

    }
}
