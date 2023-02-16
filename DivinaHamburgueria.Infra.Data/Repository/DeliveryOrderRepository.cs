﻿using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class DeliveryOrderRepository : IDeliveryOrderRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public DeliveryOrderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<DeliveryOrder>> GetAllAsync()
        {
            return await _applicationDbContext.DeliveryOrders!
                                              .OrderByDescending(p => p.Id)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<DeliveryOrder>> GetByCodeAsync(int? code)
        {
            if (code == null || code == 0)
            {
                return await _applicationDbContext.DeliveryOrders!
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.DeliveryOrders!
                                                  .Where(h => h.Id.ToString().Contains(new string(code.ToString())))
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
        }

        public async Task<IEnumerable<DeliveryOrder>> GetByDeliveredNotSupervisedAsync()
        {
            var deliveryOrders = await _applicationDbContext.DeliveryOrders!
                                                            .Include(d => d.DeliveryOrderMenuItems)!  
                                                            .ThenInclude(dm => dm.MenuItem)
                                                            .Where(d => d.State == DeliveryOrder.DeliveryOrderState.Delivered 
                                                                    && d.Supervised == false)
                                                            .OrderByDescending(d => d.Id)
                                                            .ToListAsync();

            foreach (var deliveryOrder in deliveryOrders)
            {
                foreach (var deliveryOrderMenuItems in deliveryOrder.DeliveryOrderMenuItems!)
                {
                    if (deliveryOrderMenuItems.MenuItem!.GetType() == typeof(MenuItemRecipe))
                    {
                        deliveryOrderMenuItems.MenuItem = await _applicationDbContext.MenuItemsRecipe!.Include(m => m.Ingredients)!
                                                                                                      .ThenInclude(i => i.Unity)
                                                                                                      .SingleOrDefaultAsync(m => m.Id == deliveryOrderMenuItems.MenuItem.Id);
                    }
                }
            }

            return deliveryOrders;

        }

        public async Task<DeliveryOrder?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.DeliveryOrders!.Include(i => i.DeliveryOrderMenuItems)
                                                              .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DeliveryOrder> CreateAsync(DeliveryOrder deliveryOrder)
        {
            _applicationDbContext.Add(deliveryOrder);
            await _applicationDbContext.SaveChangesAsync();
            return deliveryOrder;
        }

        public async Task<DeliveryOrder> UpdateAsync(DeliveryOrder deliveryOrder)
        {
            var previousDeliveryOrder = await _applicationDbContext.DeliveryOrders!.Include(i => i.DeliveryOrderMenuItems)
                                                                                   .AsNoTracking()
                                                                                   .SingleOrDefaultAsync(i => i.Id == deliveryOrder.Id);
            var currentDeliveryOrderMenuItemsList = deliveryOrder.DeliveryOrderMenuItems!.ToList();

            foreach (var previousDeliveryOrderMenuItem in previousDeliveryOrder!.DeliveryOrderMenuItems!)
            {
                var currentDeliveryOrderInventoryItem = currentDeliveryOrderMenuItemsList.Find(p => p.Id == previousDeliveryOrderMenuItem.Id);
                if (currentDeliveryOrderInventoryItem == null)
                    _applicationDbContext.Remove(previousDeliveryOrderMenuItem);
            }

            _applicationDbContext.Update(deliveryOrder);
            await _applicationDbContext.SaveChangesAsync();
            return deliveryOrder;
        }

        public async Task<DeliveryOrder> RemoveAsync(DeliveryOrder deliveryOrder)
        {
            _applicationDbContext.Remove(deliveryOrder);
            await _applicationDbContext.SaveChangesAsync();
            return deliveryOrder;
        }

    }
}
