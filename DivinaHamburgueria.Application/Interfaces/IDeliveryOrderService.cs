using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IDeliveryOrderService
    {
        Task<IEnumerable<DeliveryOrderDTO>> GetAll();
        Task<DeliveryOrderDTO?> GetById(int id);
        Task Add(DeliveryOrderDTO deliveryOrderDTO);
        Task Update(DeliveryOrderDTO deliveryOrderDTO);
        Task Remove(int id);
    }
}
