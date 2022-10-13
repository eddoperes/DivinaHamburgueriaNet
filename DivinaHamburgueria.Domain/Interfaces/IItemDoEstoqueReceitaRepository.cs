using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IItemDoEstoqueReceitaRepository
    {

        Task<IEnumerable<ItemDoEstoqueReceita>> GetAllAsync();
        Task<ItemDoEstoqueReceita?> GetByIdAsync(int id);

        Task<ItemDoEstoqueReceita> CreateAsync(ItemDoEstoqueReceita itemDoEstoqueReceita);
        Task<ItemDoEstoqueReceita> UpdateAsync(ItemDoEstoqueReceita itemDoEstoqueReceita);
        Task<ItemDoEstoqueReceita> RemoveAsync(ItemDoEstoqueReceita itemDoEstoqueReceita);

    }
}
