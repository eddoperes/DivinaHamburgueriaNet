using DivinaHamburgueria.Domain.Entities;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IEatableRepository
    {

        Task<Eatable?> GetByNameAsync(string name);

    }
}
