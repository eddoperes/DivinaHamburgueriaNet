using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace DivinaHamburgueria.Application.Services
{
    public class InventorySupervisorService : IInventorySupervisorService
    {

        private readonly IAlarmRepository _alarmRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public InventorySupervisorService(IAlarmRepository alarmRepository,
                                          IInventoryRepository inventoryRepository,
                                          IPurchaseOrderRepository purchaseOrderRepository)
        {
            _alarmRepository = alarmRepository;
            _inventoryRepository = inventoryRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task Execute()
        {

            await SupervisePurchaseOrders();
            await SuperviseHallOrders();
            await SuperviseDeliveryOrders();
            await TriggerAlarms();

        }

        private async Task SupervisePurchaseOrders()
        {

            var purchaseOrders = await _purchaseOrderRepository.GetByArrivedNotSupervisedAsync();

            foreach (var purchaseOrder in purchaseOrders)
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        foreach (var purchaseOrderInventoryItem in purchaseOrder.PurchaseOrderInventoryItems!)
                        {
                            Inventory? inventory = await _inventoryRepository.GetByInventoryItemAsync(purchaseOrderInventoryItem.InventoryItemId);
                            if (inventory == null)
                            {
                                var inventoryNew = new Inventory(purchaseOrderInventoryItem.InventoryItemId, purchaseOrderInventoryItem.Quantity);
                                await _inventoryRepository.CreateAsync(inventoryNew);
                            }
                            else
                            {
                                inventory.addQuantity((float)purchaseOrderInventoryItem.Quantity);
                                await _inventoryRepository.UpdateAsync(inventory);
                            }
                        }
                        purchaseOrder.NotifySupurvised();
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

        private async Task SuperviseHallOrders()
        {

        }

        private async Task SuperviseDeliveryOrders()
        {

        }

        private async Task TriggerAlarms()
        {

            var alarms = await _alarmRepository.GetAllAsync();

            foreach (var alarm in alarms)
            {


                //EatableId
                //MinimumQuantity
                //VerifiedQuantity
                //UnityId

                //EatableId
                //ValidityInDays
                //VerifiedInDays


            }

        }

    }
}
