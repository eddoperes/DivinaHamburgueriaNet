using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IItemDoEstoqueRevendaService
    {

        Task<IEnumerable<ItemDoEstoqueRevendaDTO>> GetAll();
        Task<ItemDoEstoqueRevendaDTO?> GetById(int id);
        Task Add(ItemDoEstoqueRevendaDTO itemDoEstoqueRevendaDTO);
        Task Update(ItemDoEstoqueRevendaDTO itemDoEstoqueRevendaDTO);
        Task Remove(int id);

    }
}
