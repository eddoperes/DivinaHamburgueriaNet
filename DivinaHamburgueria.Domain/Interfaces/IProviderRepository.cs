using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IProviderRepository
    {

        Task<IEnumerable<Provider>> GetAllAsync();
        Task<IEnumerable<Provider>> GetByNameAsync(string? name);
        Task<Provider?> GetByIdAsync(int id);
        Task<Provider> CreateAsync(Provider provider);
        Task<Provider> UpdateAsync(Provider provider);
        Task<Provider> RemoveAsync(Provider provider);

    }
}
