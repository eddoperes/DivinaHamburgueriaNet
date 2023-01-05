using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IHallOrderRepository
    {

        Task<IEnumerable<HallOrder>> GetAllAsync();
        Task<HallOrder?> GetByIdAsync(int id);
        Task<HallOrder> CreateAsync(HallOrder hallOrder);
        Task<HallOrder> UpdateAsync(HallOrder hallOrder);
        Task<HallOrder> RemoveAsync(HallOrder hallOrder);

    }
}
