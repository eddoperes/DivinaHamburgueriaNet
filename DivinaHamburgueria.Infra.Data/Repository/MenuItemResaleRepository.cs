using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class MenuItemResaleRepository : IMenuItemResaleRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public MenuItemResaleRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<MenuItemResale>> GetAllAsync()
        {
            return await _applicationDbContext.MenuItemsResale!.ToListAsync();
        }

        public async Task<IEnumerable<MenuItemResale>> GetByNameAsync(string? name)
        {
            if (name != null)
            {
                return await _applicationDbContext.MenuItemsResale!
                                                  .Where(m => m.Name.Contains(name))
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.MenuItemsResale!.ToListAsync();
            }
        }

        public async Task<MenuItemResale?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.MenuItemsResale!.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MenuItemResale> CreateAsync(MenuItemResale menuItemResale)
        {
            _applicationDbContext.Add(menuItemResale);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemResale;
        }

        public async Task<MenuItemResale> UpdateAsync(MenuItemResale menuItemResale)
        {
            _applicationDbContext.Update(menuItemResale);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemResale;
        }

        public async Task<MenuItemResale> RemoveAsync(MenuItemResale menuItemResale)
        {
            _applicationDbContext.Remove(menuItemResale);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemResale;
        }

    }
}
