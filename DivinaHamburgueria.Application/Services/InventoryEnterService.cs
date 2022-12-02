using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class InventoryEnterService: IInventoryEnterService
    {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public InventoryEnterService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task Execute()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
 
                    var purchaseOrders = await _purchaseOrderRepository.GetByStatusAsync(PurchaseOrder.PurchaseOrderState.Arrived);
                    
                    foreach(var purchaseOrder in purchaseOrders)
                    {
                        foreach(var purchaseOrderInventoryItem in purchaseOrder.PurchaseOrderInventoryItems!)
                        {
                            // purchaseOrderInventoryItem.InventoryItemId;
                        }
                    }

                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
