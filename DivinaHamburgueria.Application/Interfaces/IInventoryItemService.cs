using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IInventoryItemService
    {

        Task<IEnumerable<InventoryItemDTO>> GetAll();
        Task<IEnumerable<EatableDTO>> GetDistinctNames();
        Task<IEnumerable<InventoryItemDTO>> GetByNameAndOrType(string? name, string? type);
        Task<InventoryItemDTO?> GetById(int id);
        Task Add(InventoryItemDTO inventoryItemDTO);
        Task Update(InventoryItemDTO inventoryItemDTO);
        Task Remove(int id);

    }
}
