using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class InventoryEnterService: IInventoryEnterService
    {

        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public InventoryEnterService(IInventoryRepository inventoryRepository,
                                     IPurchaseOrderRepository purchaseOrderRepository)
        {
            _inventoryRepository = inventoryRepository;
            _purchaseOrderRepository = purchaseOrderRepository;            
        }

        public async Task Execute()
        {

            var purchaseOrders = await _purchaseOrderRepository.GetByStatusAsync(PurchaseOrder.PurchaseOrderState.Arrived);

            foreach (var purchaseOrder in purchaseOrders)
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {                                        
                        foreach(var purchaseOrderInventoryItem in purchaseOrder.PurchaseOrderInventoryItems!)
                        {
                            Inventory? inventory = await _inventoryRepository.GetByInventoryItemAsync(purchaseOrderInventoryItem.InventoryItemId);
                            if (inventory == null)
                            {
                                var inventoryNew = new Inventory(purchaseOrderInventoryItem.InventoryItemId, purchaseOrderInventoryItem.Quantity);
                                await _inventoryRepository.CreateAsync(inventoryNew); 
                            }
                            else
                            {
                                inventory.addQuantity((float) purchaseOrderInventoryItem.Quantity);
                                await _inventoryRepository.UpdateAsync(inventory);
                            }
                        }
                        purchaseOrder.RegisterState(PurchaseOrder.PurchaseOrderState.Stocked);
                        await _purchaseOrderRepository.UpdateAsync(purchaseOrder);                    
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
}
