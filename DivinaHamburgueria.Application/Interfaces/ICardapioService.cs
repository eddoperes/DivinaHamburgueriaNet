using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface ICardapioService
    {

        Task<IEnumerable<CardapioDTO>> GetAll();
        Task<CardapioDTO?> GetById(int id);
        Task Add(CardapioDTO cardapioDto);
        Task Update(CardapioDTO cardapioDto);
        Task Remove(int id);

    }
}
