using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IItemDoEstoqueReceitaService
    {

        Task<IEnumerable<ItemDoEstoqueReceitaDTO>> GetAll();
        Task<ItemDoEstoqueReceitaDTO?> GetById(int id);
        Task Add(ItemDoEstoqueReceitaDTO itemDoEstoqueDTO);
        Task Update(ItemDoEstoqueReceitaDTO itemDoEstoqueDTO);
        Task Remove(int id);

    }
}
