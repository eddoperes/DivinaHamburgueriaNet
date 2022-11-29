using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IPurchaseOrderService
    {

        Task<IEnumerable<PurchaseOrderDTO>> GetAll();
        Task<IEnumerable<PurchaseOrderDTO>> GetByProvider(int? providerid);
        Task<PurchaseOrderDTO?> GetById(int id);
        Task Add(PurchaseOrderDTO purchaseOrderDTO);
        Task Update(PurchaseOrderDTO purchaseOrderDTO);
        Task Remove(int id);

        Task<PurchaseOrderDTO?> Patch(int id, PurchaseOrderPatchDTO purchaseOrderPatchDTO);        

    }
}
