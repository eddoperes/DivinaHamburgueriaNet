using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IEatableRepository
    {

        Task<IEnumerable<Eatable>> GetAllAsync();
        Task<Eatable?> GetByNameAsync(string name);

    }
}
