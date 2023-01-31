using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IDeliveryOrderService
    {
        Task<IEnumerable<DeliveryOrderDTO>> GetAll();
        Task<IEnumerable<DeliveryOrderDTO>> GetByCode(int? code);
        Task<DeliveryOrderDTO?> GetById(int id);
        Task Add(DeliveryOrderDTO deliveryOrderDTO);
        Task Update(DeliveryOrderDTO deliveryOrderDTO);
        Task Remove(int id);

        Task<DeliveryOrderDTO?> Patch(int id, DeliveryOrderPatchDTO deliveryOrderPatchDTO);

    }
}
