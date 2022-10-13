using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IItemDoEstoqueRepository
    {

        Task<IEnumerable<ItemDoEstoque>> GetAllAsync();
        Task<ItemDoEstoque?> GetByIdAsync(int id);

        Task<ItemDoEstoque> CreateAsync(ItemDoEstoque itemDoEstoque);
        Task<ItemDoEstoque> UpdateAsync(ItemDoEstoque itemDoEstoque);
        Task<ItemDoEstoque> RemoveAsync(ItemDoEstoque itemDoEstoque);

    }
}
