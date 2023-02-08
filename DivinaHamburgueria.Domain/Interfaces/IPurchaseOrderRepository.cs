using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IPurchaseOrderRepository
    {

        Task<IEnumerable<PurchaseOrder>> GetAllAsync();
        Task<IEnumerable<PurchaseOrder>> GetByProviderAsync(int? providerid);
        Task<IEnumerable<PurchaseOrder>> GetByArrivedNotSupervisedAsync();

        Task<PurchaseOrder?> GetByIdAsync(int id);       
        Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder);
        Task<PurchaseOrder> UpdateAsync(PurchaseOrder purchaseOrder);
        Task<PurchaseOrder> RemoveAsync(PurchaseOrder purchaseOrder);

    }
}
