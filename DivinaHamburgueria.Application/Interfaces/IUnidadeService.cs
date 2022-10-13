using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IUnidadeService
    {

        Task<IEnumerable<UnidadeDTO>> GetAll();
        Task<UnidadeDTO?> GetById(int id);
        Task Add(UnidadeDTO unidadeDTO);
        Task Update(UnidadeDTO unidadeDTO);
        Task Remove(int id);

    }
}
