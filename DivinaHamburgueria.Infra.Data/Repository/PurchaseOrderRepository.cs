using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
        {
            return await _applicationDbContext.PurchaseOrders!.ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.PurchaseOrders!.Include(i => i.PurchaseOrderInventoryItems)
                                                              .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder)
        {
            _applicationDbContext.Add(purchaseOrder);
            await _applicationDbContext.SaveChangesAsync();
            return purchaseOrder;
        }

        public async Task<PurchaseOrder> UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _applicationDbContext.Update(purchaseOrder);
            await _applicationDbContext.SaveChangesAsync();
            return purchaseOrder;
        }

        public async Task<PurchaseOrder> RemoveAsync(PurchaseOrder purchaseOrder)
        {
            _applicationDbContext.Remove(purchaseOrder);
            await _applicationDbContext.SaveChangesAsync();
            return purchaseOrder;
        }

    }
}
