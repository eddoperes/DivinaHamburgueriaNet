using DivinaHamburgueria.Domain.Entities;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IComestivelRepository
    {

        Task<Comestivel?> GetByNameAsync(string name);

    }
}
