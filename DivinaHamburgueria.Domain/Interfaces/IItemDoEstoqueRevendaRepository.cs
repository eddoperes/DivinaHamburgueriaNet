using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IItemDoEstoqueRevendaRepository
    {

        Task<IEnumerable<ItemDoEstoqueRevenda>> GetAllAsync();
        Task<ItemDoEstoqueRevenda?> GetByIdAsync(int id);

        Task<ItemDoEstoqueRevenda> CreateAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda);
        Task<ItemDoEstoqueRevenda> UpdateAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda);
        Task<ItemDoEstoqueRevenda> RemoveAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda);

    }
}
