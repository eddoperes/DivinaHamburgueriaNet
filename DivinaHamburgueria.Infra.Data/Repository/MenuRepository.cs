using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class MenuRepository : IMenuRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public MenuRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _applicationDbContext.Menus!.ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Menus!.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Menu> CreateAsync(Menu menu)
        {
            _applicationDbContext.Add(menu);
            await _applicationDbContext.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> UpdateAsync(Menu menu)
        {
            _applicationDbContext.Update(menu);
            await _applicationDbContext.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> RemoveAsync(Menu menu)
        {
            _applicationDbContext.Remove(menu);
            await _applicationDbContext.SaveChangesAsync();
            return menu;
        }

    }
}
