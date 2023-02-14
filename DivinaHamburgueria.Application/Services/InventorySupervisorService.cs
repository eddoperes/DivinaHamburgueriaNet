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
        private readonly IHallOrderRepository _hallOrderRepository;
        private readonly IDeliveryOrderRepository _deliveryOrderRepository;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        private readonly IQuantityAlarmTriggeredRepository _quantityAlarmTriggeredRepository;
        private readonly IValidityAlarmTriggeredRepository _validityAlarmTriggeredRepository;

        public InventorySupervisorService(IAlarmRepository alarmRepository,
                                          IInventoryRepository inventoryRepository,
                                          IHallOrderRepository hallOrderRepository,                                          
                                          IDeliveryOrderRepository deliveryOrderRepository,
                                          IPurchaseOrderRepository purchaseOrderRepository,
                                          IQuantityAlarmTriggeredRepository quantityAlarmTriggeredRepository,
                                          IValidityAlarmTriggeredRepository validityAlarmTriggeredRepository)
        {
            _alarmRepository = alarmRepository;
            _inventoryRepository = inventoryRepository;
            _hallOrderRepository = hallOrderRepository;
            _deliveryOrderRepository = deliveryOrderRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _quantityAlarmTriggeredRepository = quantityAlarmTriggeredRepository;
            _validityAlarmTriggeredRepository = validityAlarmTriggeredRepository;
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
                        purchaseOrder.NotifySupervised();
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
            var hallOrders = await _hallOrderRepository.GetByServedNotSupervisedAsync();
            foreach (var hallOrder in hallOrders)
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        foreach (var hallOrderMenuItem in hallOrder.HallOrderMenuItems!)
                        {
                            await SubtractFromInventory(hallOrderMenuItem.MenuItem!);
                        }
                        hallOrder.NotifySupervised();
                        await _hallOrderRepository.UpdateAsync(hallOrder);
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private async Task SuperviseDeliveryOrders()
        {
            var deliveryOrders = await _deliveryOrderRepository.GetByDeliveredNotSupervisedAsync();
            foreach (var deliveryOrder in deliveryOrders)
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        foreach (var deliveryOrderMenuItem in deliveryOrder.DeliveryOrderMenuItems!)
                        {
                            await SubtractFromInventory(deliveryOrderMenuItem.MenuItem!);
                        }
                        deliveryOrder.NotifySupervised();
                        await _deliveryOrderRepository.UpdateAsync(deliveryOrder);
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private async Task TriggerAlarms()
        {

            var alarms = await _alarmRepository.GetAllAsync();

            foreach (var alarm in alarms)
            {

                var updatedDate = DateTime.Now;

                var inventories = await _inventoryRepository.GetByEatableAsync(alarm.EatableId);
                float verifiedQuantity = 0.0f;                
                foreach (var inventory in inventories)
                {
                    var unitConversionFactor = Unity.FindUnitConversionFactor(inventory.InventoryItem!.Unity!.Name, alarm.Unity!.Name);
                    verifiedQuantity += inventory.Quantity * unitConversionFactor;
                }
                if (verifiedQuantity < alarm.MinimumQuantity)
                {
                    var quantityAlarmTriggered = await _quantityAlarmTriggeredRepository.GetByEatableAsync(alarm.EatableId);
                    if (quantityAlarmTriggered == null)
                    {
                        quantityAlarmTriggered = new QuantityAlarmTriggered(alarm.EatableId,
                                                                            alarm.MinimumQuantity, 
                                                                            verifiedQuantity,
                                                                            alarm.UnityId,
                                                                            updatedDate);
                        await _quantityAlarmTriggeredRepository.CreateAsync(quantityAlarmTriggered);
                    }
                    else
                    {
                        quantityAlarmTriggered.Update(alarm.MinimumQuantity,
                                                      verifiedQuantity,
                                                      alarm.UnityId,
                                                      updatedDate);
                        await _quantityAlarmTriggeredRepository.UpdateAsync(quantityAlarmTriggered);
                    }
                }
                await _quantityAlarmTriggeredRepository.RemoveBeforeDateAsync(updatedDate);

                DateTime limitDate = DateTime.Now.AddDays(alarm.ValidityInDays * -1);
                var purchaseOrders = await _purchaseOrderRepository.GetByArrivedAfterDateAsync(limitDate);
                float verifiedQuantityAfterDate = 0.0f;
                foreach (var purchaseOrder in purchaseOrders)
                {
                    foreach (var purchaseOrderInventoryItem in purchaseOrder.PurchaseOrderInventoryItems!)
                    {
                        if (purchaseOrderInventoryItem.InventoryItem!.EatableId == alarm.EatableId)
                        {
                            var unitConversionFactor = Unity.FindUnitConversionFactor(purchaseOrderInventoryItem.InventoryItem!.Unity!.Name, alarm.Unity!.Name);
                            verifiedQuantityAfterDate += purchaseOrderInventoryItem.Quantity * unitConversionFactor;
                        }
                    }
                }
                if (verifiedQuantityAfterDate < verifiedQuantity)
                {
                    var validityAlarmTriggered = await _validityAlarmTriggeredRepository.GetByEatableAsync(alarm.EatableId);
                    if (validityAlarmTriggered == null)
                    {
                        validityAlarmTriggered = new ValidityAlarmTriggered(alarm.EatableId,
                                                                            alarm.ValidityInDays,
                                                                            verifiedQuantity - verifiedQuantityAfterDate,
                                                                            alarm.UnityId,
                                                                            updatedDate);
                        await _validityAlarmTriggeredRepository.CreateAsync(validityAlarmTriggered);
                    }
                    else
                    {
                        validityAlarmTriggered.Update(alarm.ValidityInDays,
                                                      verifiedQuantity - verifiedQuantityAfterDate,
                                                      alarm.UnityId,
                                                      updatedDate);
                        await _validityAlarmTriggeredRepository.UpdateAsync(validityAlarmTriggered);
                    }
                }
                await _validityAlarmTriggeredRepository.RemoveBeforeDateAsync(updatedDate);

            }

        }

        private async Task SubtractFromInventory(MenuItem menuItem)
        {
            if (menuItem.GetType() == typeof(MenuItemRecipe))
            {
                MenuItemRecipe menuItemRecipe = (MenuItemRecipe) menuItem;
                foreach (var ingredient in menuItemRecipe.Ingredients!)
                {
                    var inventories = await _inventoryRepository.GetByEatableAsync(ingredient.EatableId);
                    foreach (var inventory in inventories)
                    {
                        var unitConversionFactor = Unity.FindUnitConversionFactor(ingredient.Unity!.Name, inventory.InventoryItem!.Unity!.Name);
                        inventory.subtractQuantity((float) ingredient.Quantity * unitConversionFactor);
                        await _inventoryRepository.UpdateAsync(inventory);
                        break;
                    }
                }
            }
            else if (menuItem.GetType() == typeof(MenuItemResale))
            {
                MenuItemResale menuItemResale = (MenuItemResale) menuItem;
                Inventory? inventory = await _inventoryRepository.GetByInventoryItemAsync(menuItemResale.InventoryItemId);
                if (inventory != null)
                {
                    inventory.subtractQuantity(1.0f);
                    await _inventoryRepository.UpdateAsync(inventory);
                }
            }
        }

    }
}
