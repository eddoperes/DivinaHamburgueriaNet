using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IItemDoEstoqueService
    {

        Task<IEnumerable<ItemDoEstoqueDTO>> GetAll();
        Task<ItemDoEstoqueDTO?> GetById(int id);
        Task Add(ItemDoEstoqueDTO itemDoEstoqueDTO);
        Task Update(ItemDoEstoqueDTO itemDoEstoqueDTO);
        Task Remove(int id);

    }
}
