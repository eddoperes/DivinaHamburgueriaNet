using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _applicationDbContext.PurchaseOrders!
                                              .OrderByDescending(p => p.Id)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetByProviderAsync(int? providerid)
        {
            if (providerid != null && providerid > 0)
            {
                return await _applicationDbContext.PurchaseOrders!
                                                  .Where(p => p.ProviderId == providerid)
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.PurchaseOrders!
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
        }

        public async Task<IEnumerable<PurchaseOrder>> GetByStatusAsync(PurchaseOrder.PurchaseOrderState state)
        {
            return await _applicationDbContext.PurchaseOrders!
                                  .Include(i => i.PurchaseOrderInventoryItems)
                                  .Where(p => p.State == state)
                                  .OrderByDescending(p => p.Id)
                                  .ToListAsync();
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

            var previousPurchaseOrder = await _applicationDbContext.PurchaseOrders!.Include(i => i.PurchaseOrderInventoryItems)
                                                                                   .AsNoTracking()   
                                                                                   .SingleOrDefaultAsync(i => i.Id == purchaseOrder.Id);
            var currentPurchaseOrderInventoryItemsList = purchaseOrder.PurchaseOrderInventoryItems!.ToList();

            foreach (var previousPurchaseOrderInventoryItem in previousPurchaseOrder!.PurchaseOrderInventoryItems!)
            {
                var currentPurchaseOrderInventoryItem = currentPurchaseOrderInventoryItemsList.Find(p => p.Id == previousPurchaseOrderInventoryItem.Id);
                if (currentPurchaseOrderInventoryItem == null)
                    _applicationDbContext.Remove(previousPurchaseOrderInventoryItem);                
            }

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
