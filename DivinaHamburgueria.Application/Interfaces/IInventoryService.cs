using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IInventoryService
    {

        Task<IEnumerable<InventoryDTO>> GetAll();
        Task<IEnumerable<InventoryDTO>> GetByEatable(int? eatableid);
        Task<InventoryDTO?> GetById(int id);
        Task Add(InventoryDTO inventoryDTO);
        Task Update(InventoryDTO inventoryDTO);
        Task Remove(int id);

    }
}
