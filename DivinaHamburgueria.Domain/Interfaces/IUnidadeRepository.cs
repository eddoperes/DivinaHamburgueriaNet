using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IUnidadeRepository
    {

        Task<IEnumerable<Unidade>> GetAllAsync();
        Task<Unidade?> GetByIdAsync(int id);

        Task<Unidade> CreateAsync(Unidade unidade);
        Task<Unidade> UpdateAsync(Unidade unidade);
        Task<Unidade> RemoveAsync(Unidade unidade);

    }
}
