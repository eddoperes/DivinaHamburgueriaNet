using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class HallOrderRepository : IHallOrderRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public HallOrderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<HallOrder>> GetAllAsync()
        {
            return await _applicationDbContext.HallOrders!
                                              .OrderByDescending(p => p.Id)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<HallOrder>> GetByCodeAsync(int? code)
        {
            if (code == null || code == 0)
            {
                return await _applicationDbContext.HallOrders!
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.HallOrders!
                                                  .Where(h => h.Id.ToString().Contains(new string(code.ToString())))
                                                  .OrderByDescending(p => p.Id)
                                                  .ToListAsync();
            }
        }

        public async Task<IEnumerable<HallOrder>> GetByServedNotSupervisedAsync()
        {
            var hallOrders = await _applicationDbContext.HallOrders!
                                                        .Include(h => h.HallOrderMenuItems)! 
                                                        .ThenInclude(hm => hm.MenuItem)
                                                        .Where(h => h.State == HallOrder.HallOrderState.Served 
                                                                 && h.Supervised == false)
                                                        .OrderByDescending(p => p.Id)
                                                        .ToListAsync();

            foreach (var hallOrder in hallOrders)
            {
                foreach (var hallOrderMenuItems in hallOrder.HallOrderMenuItems!)
                {
                    if (hallOrderMenuItems.MenuItem!.GetType() == typeof(MenuItemRecipe))
                    {
                        var menuItem = await _applicationDbContext.MenuItemsRecipe!.Include(m => m.Ingredients)!
                                                                                                  .ThenInclude(i => i.Unity)  
                                                                                                  .SingleOrDefaultAsync(m => m.Id == hallOrderMenuItems.MenuItem.Id);
                        hallOrderMenuItems.NotifyMenuItem(menuItem!);
                    }
                }
            }

            return hallOrders;

        }

        public async Task<HallOrder?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.HallOrders!.Include(i => i.HallOrderMenuItems)
                                                          .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<HallOrder> CreateAsync(HallOrder hallOrder)
        {
            _applicationDbContext.Add(hallOrder);
            await _applicationDbContext.SaveChangesAsync();
            return hallOrder;
        }

        public async Task<HallOrder> UpdateAsync(HallOrder hallOrder)
        {
            var previousHallOrder = await _applicationDbContext.HallOrders!.Include(i => i.HallOrderMenuItems)
                                                                           .AsNoTracking()
                                                                           .SingleOrDefaultAsync(i => i.Id == hallOrder.Id);
            var currentHallOrderMenuItemsList = hallOrder.HallOrderMenuItems!.ToList();

            foreach (var previousHallOrderMenuItem in previousHallOrder!.HallOrderMenuItems!)
            {
                var currentHallOrderInventoryItem = currentHallOrderMenuItemsList.Find(p => p.Id == previousHallOrderMenuItem.Id);
                if (currentHallOrderInventoryItem == null)
                    _applicationDbContext.Remove(previousHallOrderMenuItem);
            }

            _applicationDbContext.Update(hallOrder);
            await _applicationDbContext.SaveChangesAsync();
            return hallOrder;
        }

        public async Task<HallOrder> RemoveAsync(HallOrder hallOrder)
        {
            _applicationDbContext.Remove(hallOrder);
            await _applicationDbContext.SaveChangesAsync();
            return hallOrder;
        }

    }
}
