using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IDeliveryOrderRepository
    {

        Task<IEnumerable<DeliveryOrder>> GetAllAsync();
        Task<DeliveryOrder?> GetByIdAsync(int id);
        Task<DeliveryOrder> CreateAsync(DeliveryOrder deliveryOrder);
        Task<DeliveryOrder> UpdateAsync(DeliveryOrder deliveryOrder);
        Task<DeliveryOrder> RemoveAsync(DeliveryOrder deliveryOrder);

    }
}
