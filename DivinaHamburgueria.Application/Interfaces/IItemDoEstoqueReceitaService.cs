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
        Task Add(ItemDoEstoqueReceitaDTO itemDoEstoqueReceitaDTO);
        Task Update(ItemDoEstoqueReceitaDTO itemDoEstoqueReceitaDTO);
        Task Remove(int id);

    }
}
