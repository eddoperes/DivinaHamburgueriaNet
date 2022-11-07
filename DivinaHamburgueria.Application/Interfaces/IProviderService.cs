using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IProviderService
    {

        Task<IEnumerable<ProviderDTO>> GetAll();
        Task<ProviderDTO?> GetById(int id);
        Task Add(ProviderDTO providerDTO);
        Task Update(ProviderDTO providerDTO);
        Task Remove(int id);

    }
}
