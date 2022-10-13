using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface ICardapioRepository
    {

        Task<IEnumerable<Cardapio>> GetAllAsync();
        Task<Cardapio?> GetByIdAsync(int id);

        Task<Cardapio> CreateAsync(Cardapio cardapio);
        Task<Cardapio> UpdateAsync(Cardapio cardapio);
        Task<Cardapio> RemoveAsync(Cardapio cardapio);

    }
}
